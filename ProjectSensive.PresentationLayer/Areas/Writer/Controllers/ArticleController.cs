using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class ArticleController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ArticleController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList()
        {
            var categories = _categoryService.TGetAll();
            return View(categories);
        }
    }
}
