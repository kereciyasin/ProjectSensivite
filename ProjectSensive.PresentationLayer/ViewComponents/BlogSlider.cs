using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogSlider : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
