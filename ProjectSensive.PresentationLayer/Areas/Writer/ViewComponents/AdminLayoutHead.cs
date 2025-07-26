using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.Areas.Writer.ViewComponents
{
    public class AdminLayoutHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
