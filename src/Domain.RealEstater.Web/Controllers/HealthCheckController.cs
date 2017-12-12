using Microsoft.AspNetCore.Mvc;

namespace Domain.RealEstater.Web.Controllers
{
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        public IActionResult Check()
        {
            return Ok("I'm alive");
        }
    }
}