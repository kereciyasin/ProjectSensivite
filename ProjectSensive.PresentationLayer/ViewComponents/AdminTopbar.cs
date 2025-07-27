using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectSensive.EntityLayer.Concrete;


namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class AdminTopbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminTopbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}
