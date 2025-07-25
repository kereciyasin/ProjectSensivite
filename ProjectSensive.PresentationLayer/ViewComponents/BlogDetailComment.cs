using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogDetailComment : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public BlogDetailComment(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int articleId)
        {
            var comments = _commentService.TGetCommentsByArticle(articleId);
            return View(comments);
        }
    }
}
