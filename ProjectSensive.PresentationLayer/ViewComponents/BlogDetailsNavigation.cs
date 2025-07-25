using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogDetailsNavigation : ViewComponent
    {
        private readonly IArticleService _articleService;

        public BlogDetailsNavigation(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int currentArticleId)
        {
            var articles = _articleService.TGetAll();
            var prev = articles.Where(x => x.ArticleID < currentArticleId)
                               .OrderByDescending(x => x.ArticleID)
                               .FirstOrDefault();

            var next = articles.Where(x => x.ArticleID > currentArticleId)
                               .OrderBy(x => x.ArticleID)
                               .FirstOrDefault();

            ViewBag.Prev = prev;
            ViewBag.Next = next;

            return View();
        }
    }
}
