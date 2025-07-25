using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.EntityLayer.Concrete;
using ProjectSensive.PresentationLayer.Models;

namespace ProjectSensive.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
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
    }
}
