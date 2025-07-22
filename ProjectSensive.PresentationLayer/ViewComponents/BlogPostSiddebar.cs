using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.PresentationLayer.Models;

namespace ProjectSensive.PresentationLayer.ViewComponents
{
    public class BlogPostSiddebar : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;

        public BlogPostSiddebar(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var categoryCounts = _articleService.TGetArticleCountByCategory()
                .Select(c => new CategoryWithCountViewModel
                {
                    CategoryName = c.CategoryName,
                    Count = c.Count
                }).ToList();

            return View(categoryCounts);
        }


    }
}
