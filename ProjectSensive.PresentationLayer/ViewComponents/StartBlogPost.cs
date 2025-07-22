using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class StartBlogPost : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
