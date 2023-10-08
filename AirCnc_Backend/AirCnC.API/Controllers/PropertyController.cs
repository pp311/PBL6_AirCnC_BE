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
        public async Task<IActionResult> CreateProperty([FromBody] UpsertPropertyDto upsertPropertyDto)
        {
            if (upsertPropertyDto is null)
                return BadRequest();
            var result = await _propertyService.CreateAsync(upsertPropertyDto);
            return Ok(result);
        }

    }
}
