using AirCnC.Application.Services.Payments;
using AirCnC.Application.Services.Payments.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] CreateBookingPaymentDto createPaymentDto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress!.ToString();
            string url = await _paymentService.CreateBookingPayment(ip, createPaymentDto);
            return Ok(url);
        }

        [HttpGet("vnpay-hook-url")]
        public async Task<IActionResult> ReceiveDataFromVnp([FromQuery] VnPayReturnDto vnpayData)
        {
            await _paymentService.ReceiveDataFromVnp(vnpayData);
            return Ok(vnpayData);
        }
    }
}
