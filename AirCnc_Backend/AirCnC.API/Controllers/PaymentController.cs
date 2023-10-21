using AirCnC.Application.Services.Payments;
using AirCnC.Application.Services.Payments.Dtos;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> CreatePayment([FromBody] CreateBookingPaymentDto createPaymentDTO)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            string url = await _paymentService.CreateBookingPayment(ip, createPaymentDTO);
            return Ok(url);
        }

        [HttpGet("vnpay-hook-url")]
        public async Task<IActionResult> ReceiveDataFromVNP([FromQuery] VNPayReturnDTO vnpayData)
        {
            await _paymentService.ReceiveDataFromVNP(vnpayData);
            return Ok(vnpayData);
        }
    }
}
