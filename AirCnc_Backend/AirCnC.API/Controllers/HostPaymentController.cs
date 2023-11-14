using AirCnC.Application.Services.HostPayments;
using AirCnC.Application.Services.HostPayments.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[Route("api/host-payment")]
[ApiController]
[Authorize]
public class HostPaymentController : Controller
{
    private readonly IHostPaymentService _hostPaymentService;
    public HostPaymentController(IHostPaymentService hostPaymentService)
    {
        _hostPaymentService = hostPaymentService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] HostPaymentQueryParameters hqp)
    {
        return Ok(await _hostPaymentService.GetPaymentsAsync(hqp));
    }

    [HttpGet("{hostPaymentId:int}")]
    public async Task<IActionResult> Get(int hostPaymentId)
    {
        return Ok(await _hostPaymentService.GetPaymentAsync(hostPaymentId));
    }

    [HttpGet("host/{hostId:int}")]
    public async Task<IActionResult> GetByHostId(int hostId, [FromQuery] HostPaymentQueryParameters hqp)
    {
        return Ok(await _hostPaymentService.GetPaymentsByHostIdAsync(hostId, hqp));
    }

    [HttpPost("{hostPaymentId:int}")]
    public async Task<IActionResult> Pay(int hostPaymentId)
    {
        await _hostPaymentService.Pay(hostPaymentId);
        return Ok();
    }
}
