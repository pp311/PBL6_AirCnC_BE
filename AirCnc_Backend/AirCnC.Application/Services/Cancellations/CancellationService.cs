using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Application.Services.Cancellations.Dtos;
using AirCnC.Application.Services.Cancellations.Specifications;
using AirCnC.Application.Services.Email;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.BookingCancellationException;
using AutoMapper;
using AirCnC.Application.Services.Payments.Dtos;
using Microsoft.Extensions.Options;
using System.Text;
using AirCnC.Application.Commons.Helpers;
using Newtonsoft.Json;
using Message = AirCnC.Application.Services.Email.Message;

namespace AirCnC.Application.Services.Cancellations;

public interface ICancellationService
{
    Task<GetCancellationDto> CreateCancellationTicketAsync(CreateCancellationDto dto); 
    Task<PagedList<GetCancellationDto>> GetCancellationTicketsAsync(CancellationTicketQueryParameters ctp);
    Task<GetCancellationDto> GetCancellationTicketAsync(int cancellationTicketId);
    Task RejectCancellationTicketAsync(int cancellationTicketId, RejectCancellationTicketDto dto);
    Task AcceptCancellationTicketAsync(int cancellationTicketId, AcceptCancellationTicketDto dto);
}

public class CancellationService : ICancellationService
{
    private readonly IRepository<CancellationTicket> _cancellationTicketsRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IRepository<Host> _hostRepository;
    private readonly IRepository<VnpHistory> _vnpHistoryRepository;
    private readonly IRepository<RefundPayment> _refundPaymentRepository;
    private readonly IRepository<ChargePayment> _chargePaymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;
    private readonly PaymentConfig _paymentConfig;
    private readonly IEmailSender _emailSender;
    private readonly IMailTemplateHelper _mailTemplateHelper;

    public CancellationService(IRepository<CancellationTicket> cancellationTicketsRepository,
                               IMapper mapper,
                               IUnitOfWork unitOfWork,
                               IRepository<Booking> bookingRepository,
                               ICurrentUser currentUser,
                               IRepository<Guest> guestRepository,
                               IRepository<VnpHistory> vnpHistoryRepository,
                               IRepository<RefundPayment> refundPaymentRepository,
                               IRepository<ChargePayment> chargePaymentRepository, 
                               IOptions<PaymentConfig> paymentConfig,
                               IRepository<Host> hostRepository,
                               IEmailSender emailSender,
                               IMailTemplateHelper mailTemplateHelper)
    {
        _cancellationTicketsRepository = cancellationTicketsRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _bookingRepository = bookingRepository;
        _currentUser = currentUser;
        _guestRepository = guestRepository;
        _hostRepository = hostRepository;
        _vnpHistoryRepository = vnpHistoryRepository;
        _refundPaymentRepository = refundPaymentRepository;
        _chargePaymentRepository = chargePaymentRepository;
        _paymentConfig = paymentConfig.Value;
        _emailSender = emailSender;
        _mailTemplateHelper = mailTemplateHelper;
    }

    public async Task<GetCancellationDto> CreateCancellationTicketAsync(CreateCancellationDto dto)
    {
        var booking = await ValidateCreateCancellation(dto);

        var cancellationTicket = _mapper.Map<CancellationTicket>(dto);

        var payoutAmount = 0.0;

        cancellationTicket.Status = CancellationTicketStatus.Pending;
        cancellationTicket.IsIssuerGuest = dto.IsGuest;
        cancellationTicket.TheOtherPartyId = dto.IsGuest ? booking.Property.HostId : booking.GuestId;
        var today = DateTime.Now;
        
        if (booking.CheckInDate.Date >= today || booking.Status is BookingStatus.CheckedIn)
            cancellationTicket.Type = CancellationTicketType.CancelledAfterCheckIn;
        else if (booking.CheckInDate.Date <= today.Date && booking.CheckInDate.Date >= today.AddDays(-1))
            cancellationTicket.Type = CancellationTicketType.CancelledBeforeCheckIn;
        else if (booking.CheckInDate.Date <= today.Date.AddDays(-1) && booking.CheckInDate.Date >= today.AddDays(-3))
            cancellationTicket.Type = CancellationTicketType.CancelledBefore1Days;
        else
            cancellationTicket.Type = CancellationTicketType.CancelledBefore3Days;

        booking.Status = booking.Status == BookingStatus.CheckedIn 
                             ? BookingStatus.CancelledAfterCheckIn 
                             : BookingStatus.CancelledBeforeCheckIn;
        
        // Todo: Calculate refund amount and charge amount
        if (cancellationTicket.IsIssuerGuest)
        {
            if (booking.CancellationPolicyType == CancellationPolicyType.Flexible)
            {
                if (cancellationTicket.Type == CancellationTicketType.CancelledAfterCheckIn)
                {
                    // Neu cancel sau checkin: tinh tien = so dem da o + 1 va co clean fee
                    var stayedFee = booking.PricePerNight * ((DateTime.Now.Date - booking.CheckInDate.Date).Days + 1);
                    cancellationTicket.RefundAmount = booking.TotalPrice - (stayedFee + booking.CleaningFee);
                    payoutAmount = stayedFee * 0.97 + booking.CleaningFee;
                }
                else if (cancellationTicket.Type == CancellationTicketType.CancelledBeforeCheckIn)
                {
                    // Neu cancel trong vong 24h truoc check-in: tinh tien = 1 dem
                    cancellationTicket.RefundAmount = booking.TotalPrice - booking.PricePerNight;
                    payoutAmount = booking.PricePerNight * 0.97;
                }
                else
                    cancellationTicket.RefundAmount = booking.TotalPrice;
            }
            else
            {
                if (cancellationTicket.Type == CancellationTicketType.CancelledAfterCheckIn)
                {
                    // Neu cancel sau checkin: tinh tien = so dem da o + 1 va 50% cac dem chua o va co clean fee
                    var stayedDays = (DateTime.Now.Date - booking.CheckInDate.Date).Days;
                    var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                    var stayedFee = booking.PricePerNight * (stayedDays + 1);
                    var notStayedFee = booking.PricePerNight * (bookingDays - stayedDays) * 0.5;
                    cancellationTicket.RefundAmount = booking.TotalPrice - (stayedFee + notStayedFee + booking.CleaningFee);
                }
                else if (cancellationTicket.Type == CancellationTicketType.CancelledBeforeCheckIn 
                         || cancellationTicket.Type == CancellationTicketType.CancelledBefore1Days)
                {
                    // Neu cancel trong vong 24h truoc check-in: tinh tien = 1 dem
                    var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                    var notStayedFee = booking.PricePerNight * bookingDays * 0.5;
                    cancellationTicket.RefundAmount = booking.TotalPrice - notStayedFee;
                }
                else
                    cancellationTicket.RefundAmount = booking.TotalPrice;
            }
        }
        else
        {
            cancellationTicket.RefundAmount = booking.TotalPrice;
            if (cancellationTicket.Type == CancellationTicketType.CancelledAfterCheckIn)
            {
                // Neu cancel sau checkin: phat tien = 50% cac dem chua o
                var stayedDays = (DateTime.Now.Date - booking.CheckInDate.Date).Days;
                var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                var notStayedFee = booking.PricePerNight * (bookingDays - stayedDays) * 0.5;
                cancellationTicket.ChargeAmount = notStayedFee;
            }
            else if (cancellationTicket.Type == CancellationTicketType.CancelledBeforeCheckIn) 
            {
                // Neu cancel trong vong 24h truoc check-in: 50%  cac dem chua o
                var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                var notStayedFee = booking.PricePerNight * bookingDays * 0.5;
                cancellationTicket.ChargeAmount = notStayedFee;
            }
            else if (cancellationTicket.Type == CancellationTicketType.CancelledBefore1Days)
            {
                // Trong vong 3 ngay: 25%
                var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                var notStayedFee = booking.PricePerNight * bookingDays * 0.25;
                cancellationTicket.ChargeAmount = notStayedFee;
            }
            else
            {
                // Truoc 3 ngay: 0%
                cancellationTicket.ChargeAmount = 0;
            }
        }
        
        // Todo: add payment cac loai (refund, charge, payout)
        _cancellationTicketsRepository.Add(cancellationTicket);
        await _unitOfWork.SaveChangesAsync(); 
        
        // Get lai cancellation ticket voi day du thong tin
        // Todo: Move mail sang background job
        cancellationTicket = await _cancellationTicketsRepository.FindOneAsync(new CancellationByIdSpecification(cancellationTicket.Id))
                             ?? throw new EntityNotFoundException(nameof(CancellationTicket), cancellationTicket.Id.ToString());

        if (cancellationTicket.IsIssuerGuest)
        {
            await SendCancellationEmailToGuestAsync(cancellationTicket);
            await SendCancellationNotiToHostAsync(cancellationTicket, payoutAmount);
        }
        
        return _mapper.Map<GetCancellationDto>(cancellationTicket);
    }
    
    public async Task<PagedList<GetCancellationDto>> GetCancellationTicketsAsync(CancellationTicketQueryParameters ctp)
    {
        var (cancellationTickets, totalCount) = await _cancellationTicketsRepository
                                                    .FindWithTotalCountAsync(new GetCancellationsSpecification(ctp));
        var cancellationTicketsDto = _mapper.Map<List<GetCancellationDto>>(cancellationTickets);
        return new PagedList<GetCancellationDto>(cancellationTicketsDto, totalCount, ctp.PageIndex, ctp.PageSize);
    }

    public async Task<GetCancellationDto> GetCancellationTicketAsync(int cancellationTicketId)
    {
        var cancellationTicket = await _cancellationTicketsRepository
                                     .FindOneAsync(new CancellationByIdSpecification(cancellationTicketId))
                                 ?? throw new EntityNotFoundException(nameof(CancellationTicket), cancellationTicketId.ToString());
        return _mapper.Map<GetCancellationDto>(cancellationTicket); 
    }

    public async Task RejectCancellationTicketAsync(int cancellationTicketId, RejectCancellationTicketDto dto)
    {
        await UpdateCancellationTicketAsync(cancellationTicketId, dto.ResolveNote, CancellationTicketStatus.Rejected);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AcceptCancellationTicketAsync(int cancellationTicketId, AcceptCancellationTicketDto dto)
    {
        var cancellationTicket = await UpdateCancellationTicketAsync(cancellationTicketId, dto.ResolveNote, CancellationTicketStatus.Resolved);
        
        var booking = await _bookingRepository.FindOneAsync(new BookingByIdSpecification(cancellationTicket.BookingId))
                      ?? throw new EntityNotFoundException(nameof(Booking), cancellationTicket.BookingId.ToString());
        
        booking.Status = cancellationTicket.CreatedAt < booking.CheckInDate 
                             ? BookingStatus.CancelledBeforeCheckIn 
                             : BookingStatus.CancelledAfterCheckIn;
        
        cancellationTicket.RefundAmount = dto.RefundAmount;
        cancellationTicket.ChargeAmount = dto.ChargeAmount;
        
        //Todo: create refund payment & charge payment      
        var bookingPayment = booking.BookingPayment;
        if(bookingPayment is null)
            throw new EntityNotFoundException(nameof(BookingPayment), booking.Id.ToString());
        var vnpHistory = bookingPayment.VnpHistories.FirstOrDefault();
        if (dto.RefundAmount!=0)
        {
            var refundPayment = (cancellationTicket.RefundPayment is not null)?cancellationTicket.RefundPayment : new RefundPayment
            {
                PaymentCode = Guid.NewGuid().ToString(),
                BookingPaymentCode = bookingPayment.PaymentCode,
                GuestId = booking.GuestId,
                Amount = cancellationTicket.RefundAmount,
                CancellationTicket = cancellationTicket,
                Status = RefundPaymentStatus.Pending
            };
            await Refund(vnpHistory, refundPayment, "0.0.0.0");
            cancellationTicket.RefundPayment = refundPayment;
        }

        if (dto.ChargeAmount != 0)
        {
            var chargePayment =(cancellationTicket.ChargePayment is not null)?cancellationTicket.ChargePayment: new ChargePayment
            {
                PaymentCode = Guid.NewGuid().ToString(),
                BookingPaymentCode = bookingPayment.PaymentCode,
                HostId = booking.Property.HostId,
                CancellationTicket = cancellationTicket,
                Amount = cancellationTicket.ChargeAmount,
                Status = ChargePaymentStatus.Pending
            };
            cancellationTicket.ChargePayment = chargePayment;
        }
    
        await _unitOfWork.SaveChangesAsync();
    }
    
    private async Task<CancellationTicket> UpdateCancellationTicketAsync(int cancellationId, string? resolveNote, CancellationTicketStatus status)
    {
        var cancellationTicket = await  _cancellationTicketsRepository
                                     .FindOneAsync(new CancellationByIdSpecification(cancellationId))
                                 ?? throw new EntityNotFoundException(nameof(CancellationTicket), cancellationId.ToString());
        
        if (cancellationTicket.Status is not CancellationTicketStatus.Pending)
            throw new BookingCancellationException("You can only reject pending cancellation tickets.");
        
        cancellationTicket.Status = status;
        cancellationTicket.ResolveNote = resolveNote;

        return cancellationTicket;
    }

    private async Task<Booking> ValidateCreateCancellation(CreateCancellationDto dto)
    {
        var booking = await _bookingRepository.FindOneAsync(new BookingByIdSpecification(dto.BookingId))
                      ?? throw new EntityNotFoundException(nameof(Booking), dto.BookingId.ToString());

        if (booking.Status is
            BookingStatus.Completed or
            BookingStatus.CancelledBeforeCheckIn or
            BookingStatus.CancelledAfterCheckIn or
            BookingStatus.Rejected)
            throw new BookingCancellationException("You can only cancel bookings that have not ended yet.");

        var currentUserId = int.Parse(_currentUser.Id!);
        if (dto.IsGuest)
        {
            var guest = await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(currentUserId))
                        ?? throw new EntityNotFoundException(nameof(Guest), currentUserId.ToString());

            if (booking.GuestId != guest.Id)
                throw new BookingCancellationException("You can only cancel your own bookings.");
        }
        else
        {
            var host = await _hostRepository.FindOneAsync(new HostByUserIdSpecification(currentUserId))
                       ?? throw new EntityNotFoundException(nameof(Host), currentUserId.ToString());
            if (booking.GuestId != host.Id)
                throw new BookingCancellationException("You can only cancel your own bookings.");
        }
        
        if ((booking.CheckOutDate.Date - DateTime.Now.Date).Days == 0)
            throw new BookingCancellationException("You can only cancel bookings at least 1 day before check-out date");      

        return booking;
    }

    private async Task Refund(VnpHistory vnpHistory, RefundPayment refundPayment,string ip)
    {
        var vnp_Api = _paymentConfig.VnpAPI;
        var vnp_HashSecret = _paymentConfig.VnpHashSecret;
        var vnp_TmnCode = _paymentConfig.VnpTmnCode;

        var vnp_RequestId = DateTime.Now.Ticks.ToString(); 
        var vnp_Version = VnPayLibrary.Version; //2.1.0
        var vnp_Command = "refund";
        var vnp_TransactionType = "03";
        var vnp_Amount = Convert.ToInt64(refundPayment.Amount*100);
        var vnp_TxnRef = vnpHistory.vnp_TxnRef;
        var vnp_OrderInfo = "Hoan tien giao dich:" +vnpHistory.vnp_TxnRef;
        var vnp_TransactionNo = ""; 
        var vnp_TransactionDate = vnpHistory.vnp_CreateDate;
        var vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss");
        var vnp_CreateBy = "admin";
        var vnp_IpAddr = ip;

        var signData = vnp_RequestId + "|" + vnp_Version + "|" + vnp_Command + "|" 
                           + vnp_TmnCode + "|" + vnp_TransactionType + "|" + vnp_TxnRef + "|" 
                           + vnp_Amount + "|" + vnp_TransactionNo + "|" + vnp_TransactionDate + "|"
                           + vnp_CreateBy + "|" + vnp_CreateDate + "|" + vnp_IpAddr + "|" + vnp_OrderInfo;
        var vnp_SecureHash = Utils.HmacSha512(vnp_HashSecret, signData);

        var rfData = new
        {
            vnp_RequestId = vnp_RequestId,
            vnp_Version = vnp_Version,
            vnp_Command = vnp_Command,
            vnp_TmnCode = vnp_TmnCode,
            vnp_TransactionType = vnp_TransactionType,
            vnp_TxnRef = vnp_TxnRef,
            vnp_Amount = vnp_Amount,
            vnp_OrderInfo = vnp_OrderInfo,
            vnp_TransactionNo = vnp_TransactionNo,
            vnp_TransactionDate = vnp_TransactionDate,
            vnp_CreateBy = vnp_CreateBy,
            vnp_CreateDate = vnp_CreateDate,
            vnp_IpAddr = vnp_IpAddr,
            vnp_SecureHash = vnp_SecureHash

        };
        var jsonData =  JsonConvert.SerializeObject(rfData);

        using (HttpClient client = new HttpClient())
        {

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make a POST request to the API
            HttpResponseMessage response = await client.PostAsync(vnp_Api, content);

            // Check if the request was successful (status code 200-299)
            if (response.IsSuccessStatusCode)
            {
                // Read and display the response content
                string responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);
                var code = responseData["vnp_ResponseCode"].ToString();
                switch (code)
                {
                    case "00":
                        refundPayment.Status = RefundPaymentStatus.Success;
                        break;
                    case "03":
                        throw new BadInputException("Dữ liệu gửi sang không đúng định dạng");
                    case "02":
                        throw new BadInputException("kiểm tra lại TmnCode");
                    case "91":
                        throw new EntityNotFoundException(nameof(refundPayment),refundPayment.PaymentCode);
                    case "94":
                        refundPayment.Status = RefundPaymentStatus.Pending;
                        throw new EntityAlreadyExistedException(nameof(refundPayment),refundPayment.PaymentCode);
                    case "95":
                        throw new ForbiddenAccessException("Giao dịch này không thành công bên VNPAY. VNPAY từ chối xử lý yêu cầu");
                    case "97":
                        throw new ForbiddenAccessException("Checksum không hợp lệ");
                    case "99":
                        throw new ForbiddenAccessException("Lỗi không xác định");
                    default:
                        refundPayment.Status = RefundPaymentStatus.Pending;
                        break;
                }
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }

    private async Task SendCancellationEmailToGuestAsync(CancellationTicket cancellationTicket)
    {
        var guest = cancellationTicket.IsIssuerGuest
            ? await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(cancellationTicket.CreatedBy!.Value))
            : await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(cancellationTicket.TheOtherPartyId));

        var booking = cancellationTicket.Booking;
        var property = cancellationTicket.Booking.Property;
        var host = property.Host;

        var template = _mailTemplateHelper.GetGuestCancellationTemplate(
                guest!.User.FullName,
                booking.CreatedAt,
                booking.Property.Title,
                booking.CheckInDate,
                booking.CheckOutDate,
                property.Address,
                property.City,
                host.User.FullName,
                host.User.PhoneNumber ?? "",
                booking.TotalPrice,
                cancellationTicket.Type.ToString(),
                cancellationTicket.RefundAmount);
        var message = new Message(new List<string> {guest.User.Email!}, "AirCnC - Thông tin hủy phòng", template);
        await _emailSender.SendEmailAsync(message);
    }
    
    private async Task SendCancellationNotiToHostAsync(CancellationTicket cancellationTicket, double payoutAmount)
    {
        var host = cancellationTicket.IsIssuerGuest
            ? await _hostRepository.FindOneAsync(new HostByUserIdSpecification(cancellationTicket.TheOtherPartyId))
            : await _hostRepository.FindOneAsync(new HostByUserIdSpecification(cancellationTicket.CreatedBy!.Value));

        var booking = cancellationTicket.Booking;
        var property = cancellationTicket.Booking.Property;
        var guest = booking.Guest;

        var template = _mailTemplateHelper.GetGuestCancellationHostNotiTemplate(
            guest!.User.FullName,
            cancellationTicket.CreatedAt,
            property.Title,
            booking.CheckInDate,
            booking.CheckOutDate,
            property.Address,
            property.City,
            booking.TotalPrice,
            cancellationTicket.Type.ToString(),
            payoutAmount);
        var message = new Message(new List<string> {host.User.Email!}, "AirCnC - Thông tin hủy phòng", template);
        await _emailSender.SendEmailAsync(message);
    }

}

public class CancellationMappingProfile : Profile
{
    public CancellationMappingProfile()
    {
        CreateMap<CreateCancellationDto, CancellationTicket>()
            .ForMember(ct => ct.CancellationReasonNote, opt => opt.MapFrom(c => c.Reason))
            .ForMember(ct => ct.Attachments, opt => opt.MapFrom(c => c.Attachments.Select(a => new CancellationTicketAttachment {Url = a})));

        CreateMap<CancellationTicket, GetCancellationDto>()
            .ForMember(dto => dto.IssuerId, opt => opt.MapFrom(ct => ct.CreatedBy))
            .ForMember(dto => dto.Attachments, opt => opt.MapFrom(ct => ct.Attachments.Select(a => a.Url)));
    }
}