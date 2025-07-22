using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class PopularPost : ViewComponent
    {
        private readonly IArticleService _articleService;

        public PopularPost(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var popularArticles = _articleService.TGetMostCommentedArticles(3);
            return View(popularArticles);
        }
    }
}
