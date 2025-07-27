using Microsoft.AspNetCore.Mvc;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class AdminHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
