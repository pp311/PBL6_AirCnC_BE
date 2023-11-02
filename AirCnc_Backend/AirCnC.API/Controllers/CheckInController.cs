using AirCnC.Application.Services.CheckIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirCnC.API.Controllers
{
    [Route("api/Checkin")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly ICheckInService _checkInService;

        public CheckInController(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }



        [HttpPut("{guid}")]
        [Authorize]
        public async Task<IActionResult> Put(string guid)
        {
            await _checkInService.CheckInAsync(guid);
            return Ok();
        }

    }
}
