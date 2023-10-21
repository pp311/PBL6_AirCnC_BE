using AirCnC.Application.Services.Properties;
using AirCnC.Application.Services.Properties.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers
{
    [Route("api/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        
        public PropertyController(IPropertyService productService)
        {
            _propertyService = productService;

        }
        [HttpGet]
        public async Task<IActionResult> GetPropertyList([FromQuery] PropertyQueryParameters pqp)
        {
            var result = await _propertyService.GetListAsync(pqp);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProperty([FromBody] UpsertPropertyDto? upsertPropertyDto)
        {
            if (upsertPropertyDto is null)
                return BadRequest();
            var result = await _propertyService.CreateAsync(upsertPropertyDto);
            return Ok(result);
        }

        [HttpGet("{propertyId:int}")]
        public async Task<IActionResult> GetPropertyById(int propertyId)
        {
            var result = await _propertyService.GetByIdAsync(propertyId);
            return Ok(result);
        }

        [HttpDelete("{propertyId:int}")]
        public async Task<IActionResult> DeleteProperty(int propertyId)
        {
            await _propertyService.DeleteByIdAsync(propertyId);
            return NoContent();
        }

        [HttpPut("{propertyId:int}")]
        public async Task<IActionResult> UpdateProperty(int propertyId, [FromBody] UpsertPropertyDto? upsertPropertyDto)
        {
            if (upsertPropertyDto is null)
                return BadRequest();
            var result = await _propertyService.UpdateAsync(propertyId, upsertPropertyDto);
            return Ok(result);
        }
        
        [HttpPost("{propertyId:int}/confirm")]
        public async Task<IActionResult> ConfirmCreatePropertyRequest(int propertyId)
        {
            await _propertyService.ConfirmCreatePropertyRequest(propertyId);
            return NoContent();
        }
        
        [HttpPost("{propertyId:int}/reject")]
        public async Task<IActionResult> RejectCreatePropertyRequest(int propertyId, RejectPropertyRequestDto dto)
        {
            await _propertyService.RejectCreatePropertyRequest(propertyId, dto);
            return NoContent();
        }
    }
}
