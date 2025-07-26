using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.Areas.Writer.Controllers
{
    public class WriterController : Controller
    {
        [Area("Writer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
