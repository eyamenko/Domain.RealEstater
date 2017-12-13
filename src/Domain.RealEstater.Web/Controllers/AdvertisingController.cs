using System;
using System.Threading.Tasks;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.RealEstater.Web.Controllers
{
    [Route("api/[controller]")]
    public class AdvertisingController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IQueueService<Property> _queueService;

        public AdvertisingController(IQueueService<Property> queueService, IPropertyService propertyService)
        {
            _queueService = queueService;
            _propertyService = propertyService;
        }

        [HttpGet("properties")]
        public async Task<IActionResult> GetProperties()
        {
            try
            {
                var properties = await _propertyService.GetAllAdvertised();

                return Ok(properties);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("properties")]
        public async Task<IActionResult> AddProperty([FromBody] Property property)
        {
            try
            {
                await _queueService.Push(property);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}