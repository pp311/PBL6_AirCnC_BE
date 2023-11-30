using AirCnC.Application.Commons;
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
        public async Task<IActionResult> CreatePayment([FromBody] CreateBookingPaymentDto createPaymentDto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress!.ToString();
            string url = await _paymentService.CreateBookingPayment(ip, createPaymentDto);
            return Ok(url);
        }

        [HttpPost("vnpay-hook-url")]
        public async Task<IActionResult> ReceiveDataFromVnp(VnPayReturnDto vnpayData)
        {
            await _paymentService.ReceiveDataFromVnp(vnpayData);
            return Ok(vnpayData);
        }
        
        [HttpGet("vnpay-hook-url")]
        public async Task<IActionResult> ReceiveDataFromVnpGet([FromQuery] VnPayReturnDto vnpayData)
        {
            await _paymentService.ReceiveDataFromVnp(vnpayData);
            return Ok(vnpayData);
        }

        [HttpGet("charge-Payment")]
        [Authorize]
        public async Task<IActionResult> ChargePayment([FromQuery] ChargePaymentQueryParameter pqp)
        {
            var result = await _paymentService.ChargePayment(pqp);
            return Ok(result);
        }

        [HttpGet("refund-Payment")]
        [Authorize]
        public async Task<IActionResult> RefundPayment([FromQuery] RefundPaymentQueryParameter pqp)
        {
            var result= await _paymentService.RefundPayment(pqp);
            return Ok(result);
        }
    }
}
