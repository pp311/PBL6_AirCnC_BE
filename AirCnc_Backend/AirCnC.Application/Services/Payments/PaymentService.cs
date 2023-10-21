using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Application.Services.Properties.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Application.Services.Payments.Dtos;
using AirCnC.Application.Services.Payments.Specifications;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Constants;
using Microsoft.Extensions.Logging;


namespace AirCnC.Application.Services.Payments;
public interface IPaymentService
{
    Task<string> CreateBookingPayment(string ip, CreateBookingPaymentDto createBookingPaymentDto);
    Task ReceiveDataFromVNP(VNPayReturnDTO vnpayReturnDTO);
    //Task<PagedList<UserVNPHistoryDTO>> GetVNPHistories(int userId, VNPParams vnpParams);
}
public class PaymentService : IPaymentService
{
    private readonly IRepository<BookingPayment> _bookingPaymentRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<VNPHistory> _vnpHistoryRepository;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PaymentConfig _paymentConfig;
    private readonly ILogger<PaymentService> _logger;


    public PaymentService(IRepository<BookingPayment> bookingPaymentRepository, IMapper mapper,
        IOptions<PaymentConfig> paymentConfig, IUnitOfWork unitOfWork, ILogger<PaymentService> logger,
        IRepository<Booking> bookingRepository, IRepository<VNPHistory> vnpHistoryRepository,
        IRepository<Guest> guestRepository
        )
    {
        _bookingPaymentRepository = bookingPaymentRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _paymentConfig = paymentConfig.Value;
        _logger = logger;
        _bookingRepository = bookingRepository;
        _vnpHistoryRepository = vnpHistoryRepository;
        _guestRepository = guestRepository;

    }

    public async Task<string> CreateBookingPayment(string ip, CreateBookingPaymentDto createBookingPaymentDto)
    {
        var temp = _paymentConfig;
        // Create DTO
        VNPHistoryDTO vnpHistoryDTO = new VNPHistoryDTO();
        vnpHistoryDTO.vnp_TxnRef = DateTime.UtcNow.Ticks;
        vnpHistoryDTO.vnp_OrderInfo = "#" + vnpHistoryDTO.vnp_TxnRef.ToString() + " | " + createBookingPaymentDto.OrderDesc;
        vnpHistoryDTO.vnp_Amount = createBookingPaymentDto.Amount;
        vnpHistoryDTO.vnp_BankCode = createBookingPaymentDto.BankCode;
        vnpHistoryDTO.vnp_TmnCode = _paymentConfig.VNPTmnCode;
        //vnpHistoryDTO.BookingPaymentId= createBookingPaymentDto.BookingId;
        vnpHistoryDTO.vnp_CreateDate = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        //Build URL for VNPAY
        VnPayLibrary vnpay = new VnPayLibrary();
        vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
        vnpay.AddRequestData("vnp_Command", "pay");
        vnpay.AddRequestData("vnp_TmnCode", vnpHistoryDTO.vnp_TmnCode);
        // Must multiply by 100 to send to vnpay system
        vnpay.AddRequestData("vnp_Amount", (vnpHistoryDTO.vnp_Amount * 100).ToString());
        vnpay.AddRequestData("vnp_BankCode", vnpHistoryDTO.vnp_BankCode);
        vnpay.AddRequestData("vnp_CreateDate", vnpHistoryDTO.vnp_CreateDate);
        vnpay.AddRequestData("vnp_CurrCode", "VND");
        vnpay.AddRequestData("vnp_Locale", "vn");
        vnpay.AddRequestData("vnp_IpAddr", ip);
        vnpay.AddRequestData("vnp_OrderInfo", vnpHistoryDTO.vnp_OrderInfo);
        vnpay.AddRequestData("vnp_ReturnUrl", _paymentConfig.VNPReturnURL);
        vnpay.AddRequestData("vnp_TxnRef", vnpHistoryDTO.vnp_TxnRef.ToString());
        vnpay.AddRequestData("vnp_OrderType", "other");

        //Create url for VNPAY
        string paymentUrl = vnpay.CreateRequestUrl(_paymentConfig.VNPUrl, _paymentConfig.VNPHashSecret, vnpHistoryDTO);

        //mapping
        VNPHistory vnpHistory = _mapper.Map<VNPHistory>(vnpHistoryDTO);

        // Create bookingPayment entity
        BookingPayment bookingPayment = new BookingPayment()
        {
            PaymentCode = Guid.NewGuid().ToString(),
            GuestId = createBookingPaymentDto.GuestId,
            BookingId = createBookingPaymentDto.BookingId,
            Amount = createBookingPaymentDto.Amount,
            Status = BookingPaymentStatus.Pending,
            VnpHistories = new List<VNPHistory>()
        };

        // save payment into db
        _bookingPaymentRepository.Add(bookingPayment);
        bookingPayment.VnpHistories.Add(vnpHistory);
        
        await _unitOfWork.SaveChangesAsync();


        return paymentUrl;
    }


    public async Task ReceiveDataFromVNP(VNPayReturnDTO vnpayReturnDTO)
    {
        VnPayLibrary vnpay = new VnPayLibrary();

        // validate hash key

        // TODO: update gold & payment status
        if (PaymentConst.VNP_TRANSACTION_STATUS_SUCCESS.Equals(vnpayReturnDTO.vnp_ResponseCode)
            && PaymentConst.VNP_TRANSACTION_STATUS_SUCCESS.Equals(vnpayReturnDTO.vnp_TransactionStatus))
        {

            Console.WriteLine("giao dich thanh cong");
            VNPHistory vnpHistory = await _vnpHistoryRepository.FindOneAsync(new VNPHistoryGetByTxnRef(vnpayReturnDTO.vnp_TxnRef));
            if (vnpHistory == null)
            {
                Console.WriteLine("Khong ton tai payment #" + vnpayReturnDTO.vnp_TxnRef);
                return;
            }

            bool checkSignature = vnpHistory.vnp_SecureHash.Equals(vnpHistory.vnp_SecureHash);
            bool isHandledOrder = PaymentConst.VNP_TRANSACTION_STATUS_SUCCESS.Equals(vnpHistory.vnp_TransactionStatus);

            if (checkSignature && !isHandledOrder)
            {
                vnpHistory.vnp_TransactionStatus = vnpayReturnDTO.vnp_TransactionStatus;
                vnpHistory.BookingPayment.Status = BookingPaymentStatus.Paid;
                _vnpHistoryRepository.Update(vnpHistory);
                await _unitOfWork.SaveChangesAsync();

            }
            else
            {
                Console.WriteLine("signature: " + checkSignature + ", order was handled: " + isHandledOrder);
            }
        }
        else
        {
            Console.WriteLine("Co loi xay ra trong qua trinh xu ly");
        }
    }

    //public async Task<PagedList<UserVNPHistoryDTO>> GetVNPHistories(int userId, VNPParams vnpParams)
    //{
    //    PagedList<vnpHistory> vnpHistoryList = await _paymentRepo.GetVNPHistories(userId, vnpParams);
    //    List<UserVNPHistoryDTO> vnpHistoryDTOList = vnpHistoryList.Records.Select(v => _mapper.Map<UserVNPHistoryDTO>(v)).ToList();
    //    return new PagedList<UserVNPHistoryDTO>(vnpHistoryDTOList, vnpHistoryList.TotalRecords);
    //}
}