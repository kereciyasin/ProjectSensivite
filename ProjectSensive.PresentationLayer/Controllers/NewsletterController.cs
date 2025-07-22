using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.DataAccessLayer.Abstract;
using ProjectSensive.EntityLayer.Concrete;

namespace ProjectSensive.PresentationLayer.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            string message;
            if (string.IsNullOrWhiteSpace(email))
            {
                message = "Please enter a valid email address!";
            }
            else
            {
                _newsletterService.TInsert(new Newsletter { NewsletterEmail = email });
                message = "Successfully subscribed! ✅";
            }
            TempData["SubscribeMessage"] = message;
            return RedirectToAction("Index", "Default");
        }
    }
}
