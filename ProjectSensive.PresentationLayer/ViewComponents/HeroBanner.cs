using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class HeroBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string today = DateTime.Now.ToString("MMMM dd, yyyy");
            ViewBag.Today = today;
            return View();
        }
    }
}
