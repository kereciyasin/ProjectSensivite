using Microsoft.AspNetCore.Mvc;
using ProjectSensive.BusinessLayer.Abstract;

namespace ProjectSensive.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.TGetAll();
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            _categoryService.TDelete(id);

            return RedirectToAction("Index", "AdminCategory", new { area = "Writer" });
        }



    }
}
