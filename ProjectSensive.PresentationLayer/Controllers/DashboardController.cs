using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.EntityLayer.Concrete;

namespace ProjectSensive.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public DashboardController(UserManager<AppUser> userManager, IArticleService articleService, ICommentService commentService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var articles = _articleService.TGetArticlesByAppUserId(user.Id);
            var commentCount = _commentService.TGetCommentsByArticle(user.Id).Count;

            ViewBag.ArticleCount = articles.Count;
            ViewBag.CommentCount = commentCount;
            ViewBag.UserName = user.Name + " " + user.Surname;
            ViewBag.ImageUrl = user.ImageUrl;

            return View(articles.Take(5).ToList());
        }
    }
}

