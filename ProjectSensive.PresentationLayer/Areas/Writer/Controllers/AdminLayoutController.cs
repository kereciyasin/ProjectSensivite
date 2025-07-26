using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
