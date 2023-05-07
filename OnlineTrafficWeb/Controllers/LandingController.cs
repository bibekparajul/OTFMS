using Microsoft.AspNetCore.Mvc;

namespace OnlineTrafficWeb.Controllers
{
    public class LandingController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
