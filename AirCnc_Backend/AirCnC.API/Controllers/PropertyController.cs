using AirCnC.Application.Services.PropertyService;
using AirCnC.Application.Services.PropertyService.Dtos;
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
        public async Task<IActionResult> CreateProperty([FromBody] UpsertPropertyDto upsertPropertyDto,int userId)
        {
            if (upsertPropertyDto is null)
                return BadRequest();
            var result = await _propertyService.CreateAsync(upsertPropertyDto,userId);
            return Ok(result);
        }

        [HttpGet("{propertyId:int}")]
        public async Task<IActionResult> GetPropertyById(int propertyId)
        {
            var result = await _propertyService.GetByIdAsync(propertyId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{propertyId:int}")]
        public async Task<IActionResult> DeleteProperty(int propertyId)
        {
            var result = await _propertyService.DeleteByIdAsync(propertyId);
            if (result is null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{propertyId:int}")]
        public async Task<IActionResult> UpdateProperty(int propertyId, [FromBody] UpsertPropertyDto upsertPropertyDto)
        {
            if (upsertPropertyDto is null)
                return BadRequest();
            var result = await _propertyService.UpdateAsync(propertyId, upsertPropertyDto);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
