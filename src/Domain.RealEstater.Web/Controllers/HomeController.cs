using Microsoft.AspNetCore.Mvc;

namespace Domain.RealEstater.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}