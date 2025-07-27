using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
