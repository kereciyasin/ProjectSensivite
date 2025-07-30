using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.EntityLayer.Concrete;
using ProjectSensive.PresentationLayer.Models;

namespace ProjectSensive.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(CommentAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    CommentDetail = model.CommentDetail,
                    ArticleID = model.ArticleID,
                    Name = model.Name,
                    Email = model.Email,
                    Status = true,
                    CommentDate = DateTime.Now
                };
                _commentService.TInsert(comment);
            }

            return RedirectToAction("Detail", "Article", new { id = model.ArticleID });
        }
        public async Task<IActionResult> MyArticleComments()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var comments = _commentService.TGetCommentsForUserArticles(user.Id);
            return View(comments);
        }
    }
}
