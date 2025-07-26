using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.EntityLayer.Concrete;

namespace ProjectSensive.PresentationLayer.Areas.Writer.ViewComponents
{
    public class AdminLayoutTopbar : ViewComponent
    {
        private readonly IAppUserService _appUserService;

        public AdminLayoutTopbar(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IViewComponentResult Invoke()
        {
            var username = User?.Identity?.Name;

            if (username != null)
            {
                var user = _appUserService.TGetAll().FirstOrDefault(x => x.UserName == username);
                return View(user);
            }

            return View(new AppUser());
        }
    }
}
