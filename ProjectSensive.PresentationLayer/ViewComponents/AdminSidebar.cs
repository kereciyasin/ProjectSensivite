using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectSensive.EntityLayer.Concrete;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class AdminSidebar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminSidebar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User?.Identity?.IsAuthenticated != true)
                return View(null); // ya da boş bir view döndür

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

    }
}