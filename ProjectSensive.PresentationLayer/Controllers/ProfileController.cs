using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectSensive.EntityLayer.Concrete;
using ProjectSensive.PresentationLayer.Models;


namespace ProjectSensive.PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            var model = new UserEditViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                ImageUrl = user.ImageUrl
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.UserName = model.Username;
            user.Email = model.Email;
            user.ImageUrl = model.ImageUrl;

            if (!string.IsNullOrEmpty(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (!passwordResult.Succeeded)
                {
                    ViewBag.Message = "Password update failed.";
                    return View(model);
                }
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                ViewBag.Message = "Profile updated successfully.";
            else
                ViewBag.Message = "An error occurred while updating.";

            return View(model);
        }
    }
}
