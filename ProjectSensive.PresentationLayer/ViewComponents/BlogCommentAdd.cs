using Microsoft.AspNetCore.Mvc;
using ProjectSensive.PresentationLayer.Models;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogCommentAdd : ViewComponent
    {
        public IViewComponentResult Invoke(int articleId)
        {
            var model = new CommentAddViewModel
            {
                ArticleID = articleId,
                AppUserId = 1 
            };

            return View(model); 
        }
    }
}
