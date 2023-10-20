using AirCnC.Application.Services.Bookings;
using AirCnC.Application.Services.Bookings.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    
    /// <summary>
    /// Trả về danh sách booking của các property của 1 host, có thể dùng filter để lấy những booking sắp đến
    /// </summary>
    /// <remarks>
    /// Pending: vừa tạo booking, đang chờ thanh toán
    /// Confirm: đã thanh toán (ban đầu là dành cho host xác nhận)
    /// Reject: cái này cũ r, ban đầu dành cho host từ chối
    /// </remarks>
    [HttpGet("host/{hostId:int}")]
    [ProducesResponseType(typeof(GetBookingForHostDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListForHostAsync(int hostId, [FromQuery] BookingQueryParameters bookingQueryParameters)
    {
        var result = await _bookingService.GetBookingsForHostAsync(hostId, bookingQueryParameters);
        return Ok(result);
    }
    
    /// <summary>
    /// Những booking mà guest đã tạo
    /// </summary>
    [HttpGet("guest/{guestId:int}")]
    [ProducesResponseType(typeof(GetBookingForGuestDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListForGuestAsync(int guestId, [FromQuery] BookingQueryParameters bookingQueryParameters)
    {
        var result = await _bookingService.GetBookingsForGuestAsync(guestId, bookingQueryParameters);
        return Ok(result);
    }
    
    /// <summary>
    /// Hiện tại thì cái này chỉ để tra cứu xem từ ngày nào đến ngày nào có những booking nào
    /// </summary>
    /// <remarks>Ngày có format là mm/dd/yyyy</remarks>
    [HttpGet("property/{propertyId:int}")]
    [ProducesResponseType(typeof(GetBookingForPropertyDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetListForPropertyAsync(int propertyId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var result = await _bookingService.GetBookingsForPropertyAsync(propertyId, fromDate, toDate);
        return Ok(result);
    }
    
    /// <summary>
    /// Cái này là khi tạo booking thì booking sẽ có trạng thái là Pending, sau khi guest thanh toán thì sẽ chuyển sang Confirm
    /// </summary>
    /// <remarks>TODO: Trả về QR code cho guest thanh toán</remarks>
    [HttpPost]
    [ProducesResponseType(typeof(GetDraftBookingDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateBookingAsync(CreateBookingDto createBookingDto)
    {
        var result = await _bookingService.CreateBookingAsync(createBookingDto);
        return Ok(result);
    }
}