using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;

namespace Investor.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly INewsService _postService;
        private readonly ICategoryService _categoryService;
        public CategoryController(INewsService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }
        public IActionResult Index(string url)
        {
            ViewBag.CategoryName = _categoryService.GetCategoryByUrlAsync(url).Result.Name;
            ViewBag.CategoryPopularPosts = _postService.GetPopularNewsByCategoryUrlAsync(url, 5).Result.ToList();
            ViewBag.CategoryPosts = _postService.GetLatestNewsByCategoryUrlAsync(url).Result.ToList();
            ViewBag.LatestPosts = _postService.GetLatestNewsAsync(20).Result.ToList();
            ViewBag.Url = url;
            return View();
        }
    }
}