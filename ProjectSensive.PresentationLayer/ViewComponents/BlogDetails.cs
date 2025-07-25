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
        public IViewComponentResult Invoke()
        {
            var articles = _articleService.TArticleListWithCategoryAndAppUser();
            return View(articles);
        }
    }
}
