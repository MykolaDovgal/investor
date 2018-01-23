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
        public IActionResult Index(string url, int numberOfPosts = 10)
        {
            ViewBag.CategoryName = _categoryService.GetCategoryByUrlAsync(url).Result.Name;
            ViewBag.CategoryPopularPosts = _postService.GetPopularNewsByCategoryUrlAsync(url, 5).Result.ToList();
            var posts = _postService.GetPagedLatestNewsByCategoryUrlAsync(url, numberOfPosts, 1).Result.ToList();
            ViewBag.CategoryPosts = posts;
            ViewBag.LatestPosts = _postService.GetLatestNewsAsync(numberOfPosts).Result.ToList();
            ViewBag.GetMoreEnabled = posts.Count == numberOfPosts && _postService.GetPagedLatestNewsByCategoryUrlAsync(url, numberOfPosts, 2).Result.Any();
            ViewBag.Url = url;
            return View();
        }
    }
}