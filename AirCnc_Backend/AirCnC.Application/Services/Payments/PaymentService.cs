using AutoMapper;
using Microsoft.Extensions.Options;
using AirCnC.Application.Commons;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Application.Services.Payments.Dtos;
using AirCnC.Application.Services.Payments.Specifications;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Constants;
using AirCnC.Domain.Exceptions;
using Microsoft.Extensions.Logging;


namespace AirCnC.Application.Services.Payments;
public interface IPaymentService
{
    Task<string> CreateBookingPayment(string ip, CreateBookingPaymentDto createBookingPaymentDto);
    Task ReceiveDataFromVnp(VnPayReturnDto vnpayReturnDto);
    //Task<PagedList<UserVNPHistoryDTO>> GetVNPHistories(int userId, VNPParams vnpParams);
}
public class PaymentService : IPaymentService
{
    private readonly IRepository<BookingPayment> _bookingPaymentRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<VnpHistory> _vnpHistoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PaymentConfig _paymentConfig;
    private readonly ILogger<PaymentService> _logger;


    public PaymentService(IRepository<BookingPayment> bookingPaymentRepository, IMapper mapper,
                          IOptions<PaymentConfig> paymentConfig, IUnitOfWork unitOfWork, IRepository<VnpHistory> vnpHistoryRepository,
                          IRepository<Booking> bookingRepository,
                          ILogger<PaymentService> logger)
    {
        _bookingPaymentRepository = bookingPaymentRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _paymentConfig = paymentConfig.Value;
        _vnpHistoryRepository = vnpHistoryRepository;
        _bookingRepository = bookingRepository;
        _logger = logger;
    }

    public async Task<string> CreateBookingPayment(string ip, CreateBookingPaymentDto createBookingPaymentDto)
    {
        var booking = await _bookingRepository.GetByIdAsync(createBookingPaymentDto.BookingId)
                      ?? throw new EntityNotFoundException(nameof(Booking), createBookingPaymentDto.BookingId.ToString());
       
        if (booking.Status != BookingStatus.Pending)
            throw new BadInputException("Booking is already processed");
        
        // Create DTO
        VnpHistoryDto vnpHistoryDto = new VnpHistoryDto();
        vnpHistoryDto.vnp_TxnRef = DateTime.UtcNow.Ticks;
        vnpHistoryDto.vnp_OrderInfo = "#" + vnpHistoryDto.vnp_TxnRef + " | " + "Thanh toan dat phong #" + booking.Id;
        vnpHistoryDto.vnp_Amount = (long)booking.TotalPrice*1000;
        vnpHistoryDto.vnp_BankCode = createBookingPaymentDto.BankCode!;
        vnpHistoryDto.vnp_TmnCode = _paymentConfig.VnpTmnCode;
        //vnpHistoryDTO.BookingPaymentId= createBookingPaymentDto.BookingId;
        vnpHistoryDto.vnp_CreateDate = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        //Build URL for VNPAY
        VnPayLibrary vnpay = new VnPayLibrary();
        vnpay.AddRequestData("vnp_Version", VnPayLibrary.Version);
        vnpay.AddRequestData("vnp_Command", "pay");
        vnpay.AddRequestData("vnp_TmnCode", vnpHistoryDto.vnp_TmnCode);
        // Must multiply by 100 to send to vnpay system
        vnpay.AddRequestData("vnp_Amount", (vnpHistoryDto.vnp_Amount * 100).ToString());
        vnpay.AddRequestData("vnp_BankCode", vnpHistoryDto.vnp_BankCode);
        vnpay.AddRequestData("vnp_CreateDate", vnpHistoryDto.vnp_CreateDate);
        vnpay.AddRequestData("vnp_CurrCode", "VND");
        vnpay.AddRequestData("vnp_Locale", "vn");
        vnpay.AddRequestData("vnp_IpAddr", ip);
        vnpay.AddRequestData("vnp_OrderInfo", vnpHistoryDto.vnp_OrderInfo);
        vnpay.AddRequestData("vnp_ReturnUrl", _paymentConfig.VnpReturnUrl);
        vnpay.AddRequestData("vnp_TxnRef", vnpHistoryDto.vnp_TxnRef.ToString());
        vnpay.AddRequestData("vnp_OrderType", "other");

        //Create url for VNPAY
        string paymentUrl = vnpay.CreateRequestUrl(_paymentConfig.VnpUrl, _paymentConfig.VnpHashSecret, vnpHistoryDto);

        //mapping
        VnpHistory vnpHistory = _mapper.Map<VnpHistory>(vnpHistoryDto);

        // Create bookingPayment entity
        var bookingPayment = await _bookingPaymentRepository.FindOneAsync(new BookingPaymentByBookingIdSpecification(createBookingPaymentDto.BookingId));
        if (bookingPayment == null)
        {
            bookingPayment ??= new BookingPayment()
            {
                PaymentCode = Guid.NewGuid().ToString(),
                GuestId = booking.GuestId,
                BookingId = booking.Id,
                Amount = booking.TotalPrice,
                Status = BookingPaymentStatus.Pending,
                VnpHistories = new List<VnpHistory>()
            };
            _bookingPaymentRepository.Add(bookingPayment);
        }
        bookingPayment.VnpHistories.Clear();
        bookingPayment.VnpHistories.Add(vnpHistory);
        
        // save payment into db
        await _unitOfWork.SaveChangesAsync();

        return paymentUrl;
    }

    public async Task ReceiveDataFromVnp(VnPayReturnDto vnpayReturnDto)
    {
        // VnPayLibrary vnpay = new VnPayLibrary();
        // validate hash key

        // TODO: update gold & payment status
        if (PaymentConst.VnpTransactionStatusSuccess.Equals(vnpayReturnDto.vnp_ResponseCode)
            && PaymentConst.VnpTransactionStatusSuccess.Equals(vnpayReturnDto.vnp_TransactionStatus))
        {

            _logger.LogInformation("giao dich thanh cong");
            VnpHistory? vnpHistory = await _vnpHistoryRepository.FindOneAsync(new VnpHistoryGetByTxnRef(vnpayReturnDto.vnp_TxnRef));
            if (vnpHistory == null)
            {
                _logger.LogError("Khong ton tai payment #" + vnpayReturnDto.vnp_TxnRef);
                return;
            }

            bool checkSignature = vnpHistory.vnp_SecureHash!.Equals(vnpHistory.vnp_SecureHash);
            bool isHandledOrder = PaymentConst.VnpTransactionStatusSuccess.Equals(vnpHistory.vnp_TransactionStatus);

            if (checkSignature && !isHandledOrder)
            {
                vnpHistory.vnp_TransactionStatus = vnpayReturnDto.vnp_TransactionStatus;
                vnpHistory.BookingPayment.Status = BookingPaymentStatus.Paid;
                _vnpHistoryRepository.Update(vnpHistory);
                
                var booking = await _bookingRepository.GetByIdAsync(vnpHistory.BookingPayment.BookingId);
                booking!.Status = BookingStatus.Confirmed;
                booking.Guid = Guid.NewGuid().ToString();
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("signature: " + checkSignature + ", order was handled: " + isHandledOrder);
            }
        }
        else
        {
            _logger.LogError("Co loi xay ra trong qua trinh xu ly");
        }
    }

    //public async Task<PagedList<UserVNPHistoryDTO>> GetVNPHistories(int userId, VNPParams vnpParams)
    //{
    //    PagedList<vnpHistory> vnpHistoryList = await _paymentRepo.GetVNPHistories(userId, vnpParams);
    //    List<UserVNPHistoryDTO> vnpHistoryDTOList = vnpHistoryList.Records.Select(v => _mapper.Map<UserVNPHistoryDTO>(v)).ToList();
    //    return new PagedList<UserVNPHistoryDTO>(vnpHistoryDTOList, vnpHistoryList.TotalRecords);
    //}
}