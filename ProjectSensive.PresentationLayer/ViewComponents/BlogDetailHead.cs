using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogDetailHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
