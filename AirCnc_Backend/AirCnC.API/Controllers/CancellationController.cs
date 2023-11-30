using AirCnC.Application.Services.Cancellations;
using AirCnC.Application.Services.Cancellations.Dtos;
using AirCnC.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[Route("api/cancellations")]
[ApiController]
[Authorize]
public class CancellationController : ControllerBase
{
    private readonly ICancellationService _cancellationService;

    public CancellationController(ICancellationService cancellationService)
    {
        _cancellationService = cancellationService;
    }
    
    /// <summary>
    /// Chua lam may cai chinh sach huy booking, chi moi tao yc huy booking
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateCancellationTicket([FromBody] CreateCancellationDto? dto)
    {
        if (dto is null)
            return BadRequest();
        await _cancellationService.CreateCancellationTicketAsync(dto);
        return NoContent();
    }
    
    /// <summary>
    /// cai nay ko co search dau XD
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetCancellationTickets([FromQuery] CancellationTicketQueryParameters ctp)
    {
        var result = await _cancellationService.GetCancellationTicketsAsync(ctp);
        return Ok(result);
    }
    
    [HttpGet("{cancellationTicketId:int}")]
    public async Task<IActionResult> GetCancellationTicket(int cancellationTicketId)
    {
        var result = await _cancellationService.GetCancellationTicketAsync(cancellationTicketId);
        return Ok(result);
    }
    
    [Authorize(Roles = AppRole.Admin)]
    [HttpPost("{cancellationTicketId:int}/reject")]
    public async Task<IActionResult> RejectCancellationTicket(int cancellationTicketId, [FromBody] RejectCancellationTicketDto? dto)
    {
        if (dto is null)
            return BadRequest();
        await _cancellationService.RejectCancellationTicketAsync(cancellationTicketId, dto);
        return NoContent();
    }
    
    [Authorize(Roles = AppRole.Admin)]
    [HttpPost("{cancellationTicketId:int}/accept")]
    public async Task<IActionResult> AcceptCancellationTicket(int cancellationTicketId, [FromBody] AcceptCancellationTicketDto? dto)
    {
        if (dto is null)
            return BadRequest();
        await _cancellationService.AcceptCancellationTicketAsync(cancellationTicketId, dto.ResolveNote,dto.RefundAmount,dto.ChargeAmount);
        return NoContent();
    }
}