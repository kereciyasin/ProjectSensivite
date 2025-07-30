using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectSensive.BusinessLayer.Abstract;
using ProjectSensive.EntityLayer.Concrete;

namespace ProjectSensive.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;


        public ArticleController(IArticleService articleService, ICategoryService categoryService, IAppUserService appUserService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _appUserService = appUserService;
            _userManager = userManager;
        }
        public async Task<IActionResult> MyArticles()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUserId(user.Id);
            return View(values);
        }

        public IActionResult ArticleList()
        {
            var values = _articleService.TGetAll();
            return View(values);
        }
        public IActionResult ArticleListWithCategory()
        {
            var values = _articleService.TArticleListWithCategory();
            return View(values);
        }
        public IActionResult ArticleListWithCategoryAndAppUser()
        {
            var values = _articleService.TArticleListWithCategoryAndAppUser();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateArticle()
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;



            var appUserList = _appUserService.TGetAll();
            List<SelectListItem> values2 = (from x in appUserList
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.v2 = values2;


            return View();
        }
        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("ArticleListWithCategoryAndAppUser");
        }

        public IActionResult Detail(int id)
        {

            var article = _articleService.TArticleListWithCategoryAndAppUser()
                     .FirstOrDefault(x => x.ArticleID == id);

            if (article == null)
                return NotFound();

            return View(article);
        }
        public IActionResult Delete(int id)
        {
            var article = _articleService.TGetById(id);

            if (article == null)
                return NotFound();

            _articleService.TDelete(id);
            return RedirectToAction("MyArticles");
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            var categoryList = _categoryService.TGetAll();
            ViewBag.Categories = categoryList.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = user.Id;
            article.CreatedDate = DateTime.Now;

            if (string.IsNullOrEmpty(article.CoverImageUrl))
            {
                article.CoverImageUrl = "/images/default-cover.jpg";
            }

            _articleService.TInsert(article);
            return RedirectToAction("MyArticles");
        }
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = _articleService.TGetById(id);

            if (article == null)
                return NotFound();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (article.AppUserId != user.Id)
                return Forbid();

            _articleService.TDelete(id);
            return RedirectToAction("MyArticles");
        }
        [HttpGet]
        public async Task<IActionResult> EditArticle(int id)
        {
            var article = _articleService.TGetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (article == null || article.AppUserId != user.Id)
                return Forbid();

            var categories = _categoryService.TGetAll();
            ViewBag.Categories = categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

            return View(article);
        }
        [HttpPost]
        public async Task<IActionResult> EditArticle(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var existingArticle = _articleService.TGetById(article.ArticleID);

            if (existingArticle == null || existingArticle.AppUserId != user.Id)
                return Forbid();


            existingArticle.Title = article.Title;
            existingArticle.Description = article.Description;
            existingArticle.CategoryID = article.CategoryID;
            existingArticle.CoverImageUrl = string.IsNullOrEmpty(article.CoverImageUrl)
                ? "/images/default-cover.jpg"
                : article.CoverImageUrl;

            _articleService.TUpdate(existingArticle);
            return RedirectToAction("MyArticles");
        }
        public IActionResult DetailArticle(int id)
        {
            var article = _articleService.TArticleListWithCategoryAndAppUser()
                             .FirstOrDefault(x => x.ArticleID == id);

            if (article == null)
                return NotFound();

            return View(article); // Views/Article/Detail.cshtml sayfasını döndürür
        }

    }


}

