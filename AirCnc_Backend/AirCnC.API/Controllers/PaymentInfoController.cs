using AirCnC.Application.Services.PaymentInfos;
using AirCnC.Application.Services.PaymentInfos.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers
{
    [Route("api/payment-info")]
    [ApiController]
    [Authorize]
    public class PaymentInfoController : ControllerBase
    {
        private readonly IPaymentInfoService _paymentInfoService;
        public PaymentInfoController(IPaymentInfoService paymentInfoService)
        {
            _paymentInfoService = paymentInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _paymentInfoService.GetPaymentInfoAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentInfoDto paymentInfoDto)
        {
            var result = await _paymentInfoService.CreatePaymentInfoAsync(paymentInfoDto);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] PaymentInfoDto paymentInfoDto)
        {
            var result = await _paymentInfoService.UpdatePaymentInfoAsync(paymentInfoDto);
            return Ok(result);
        }

        
    }
}
