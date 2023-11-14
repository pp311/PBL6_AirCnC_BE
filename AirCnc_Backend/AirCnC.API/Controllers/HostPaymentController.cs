using AirCnC.Application.Services.HostPayments;
using AirCnC.Application.Services.HostPayments.Dtos;
using AirCnC.Application.Services.Payments;
using AirCnC.Application.Services.Payments.Dtos;
using AirCnC.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers
{
    [Route("api/host-payment")]
    [ApiController]
    //[Authorize]
    public class HostPaymentController : Controller
    {
        private readonly IHostPaymentService _hostpaymentService;
        public HostPaymentController(IHostPaymentService hostpaymentService)
        {
            _hostpaymentService = hostpaymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] HostPaymentQueryParameters hqp)
        {
            try
            {
                return  Ok(await _hostpaymentService.GetPaymentsAsync(hqp));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{hostPaymentId}")]
        public async Task<IActionResult> Get(int hostPaymentId)
        {
            try
            {
                return Ok(await _hostpaymentService.GetPaymentAsync(hostPaymentId));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("Host/{HostId}")]
        public async Task<IActionResult> GetByHostId(int HostId, [FromQuery] HostPaymentQueryParameters hqp)
        {
            try
            {
                return Ok(await _hostpaymentService.GetPaymentsByHostIdAsync(HostId, hqp));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{HostPaymentId}")]
        public async Task<IActionResult> Pay(int HostPaymentId)
        {
            await _hostpaymentService.Pay(HostPaymentId);
            return Ok();
        }
        
    }
}
