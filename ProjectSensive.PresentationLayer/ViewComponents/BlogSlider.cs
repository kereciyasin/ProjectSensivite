using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogSlider : ViewComponent

    {
        private readonly IArticleService _articleService;

        public BlogSlider(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetLast5ArticlesWithCategory();
            return View(values);
        }
    }
}
