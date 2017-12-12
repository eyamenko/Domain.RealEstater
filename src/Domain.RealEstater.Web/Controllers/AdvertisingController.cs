using System.Collections.Generic;
using Domain.RealEstater.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.RealEstater.Web.Controllers
{
    [Route("api/[controller]")]
    public class AdvertisingController : Controller
    {
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
        public IActionResult AddProperty([FromBody] Property property)
        {
            return Ok(property);
        }
    }
}