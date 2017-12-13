using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.RealEstater.Web.Controllers
{
    [Route("api/[controller]")]
    public class AdvertisingController : Controller
    {
        private readonly IQueueService<Property> _queueService;

        public AdvertisingController(IQueueService<Property> queueService)
        {
            _queueService = queueService;
        }

        [HttpGet("properties")]
        public IActionResult GetProperties()
        {
            var data = new List<Property>
            {
                new Property
                {
                    AgencyCode = "LRE",
                    Name = "Luxurious Apartments",
                    Address = "4 McDonald Street, Potts Point NSW",
                    Latitude = -33.8677394m,
                    Longitude = 151.2229558m
                },
                new Property
                {
                    AgencyCode = "OTBRE",
                    Name = "Super High Apartments, Sydney",
                    Address = "32 Sir John Young Crescent, Sydney NSW",
                    Latitude = -33.8707617m,
                    Longitude = 151.2151041m
                },
                new Property
                {
                    AgencyCode = "CRE",
                    Name = "The Summit Apartments",
                    Address = "31 Hereford Street, Glebe NSW",
                    Latitude = -33.8787075m,
                    Longitude = 151.1820893m
                }
            };

            return Ok(data);
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