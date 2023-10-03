using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirCnC.Application.Services.Property;
using AirCnC.Application.Services.Property.Dtos;
using AirCnC.Application.QueryParameters;

namespace AirCnC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        
        public PropertyController(IPropertyService productService)
        {
            _propertyService = productService;

        }
        [HttpGet]
        public async Task<IActionResult> GetPropertylistAsync([FromQuery] PropertyQueryParameters pqp)
        {
            var result = await _propertyService.GetListAsync(pqp);
            return Ok(result);
        }


    }
}
