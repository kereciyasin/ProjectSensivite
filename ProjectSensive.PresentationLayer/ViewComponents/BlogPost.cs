using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogPost : ViewComponent
    {
        private readonly IArticleService _articleService;

        public BlogPost(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int page = 1)
        {
            int pageSize = 4;
            var allArticles = _articleService.TArticleListWithCategoryAndAppUser();
            var paginated = allArticles
                .OrderByDescending(x => x.CategoryID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)allArticles.Count / pageSize);
            ViewBag.CurrentPage = page;

            return View(paginated);
        }
    }
}
