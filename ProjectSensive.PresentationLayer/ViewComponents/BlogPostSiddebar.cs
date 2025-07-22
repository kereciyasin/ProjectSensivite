using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogPostSiddebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
