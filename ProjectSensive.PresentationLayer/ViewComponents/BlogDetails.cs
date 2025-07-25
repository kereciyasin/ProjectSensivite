using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogDetails : ViewComponent
    {
        private readonly IArticleService _articleService;

        public BlogDetails(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var article = _articleService.TArticleListWithCategoryAndAppUser()
                                      .FirstOrDefault(x => x.ArticleID == id);
            return View(article);
        }
    }
}
