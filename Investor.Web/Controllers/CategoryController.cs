using System.Collections.Generic;
using System.Linq;
using Investor.Model;
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
        public IActionResult Index(string categoryUrl, int numberOfPosts = 10)
        {

            Category category = _categoryService.GetCategoryByUrlAsync(categoryUrl).Result;

            if (category == null)
            {
                Response.StatusCode = 404;
                return StatusCode(Response.StatusCode);
            }

            ViewBag.CategoryName = category.Name;
            ViewBag.CategoryPopularPosts = _postService.GetPopularNewsByCategoryUrlAsync(categoryUrl, 5).Result.ToList();
            List<PostPreview> posts = _postService.GetPagedLatestNewsByCategoryUrlAsync(categoryUrl, numberOfPosts, 1).Result.ToList();
            ViewBag.CategoryPosts = posts;
            ViewBag.LatestPosts = _postService.GetLatestNewsAsync(numberOfPosts).Result.ToList();
            ViewBag.GetMoreEnabled = posts.Count == numberOfPosts && _postService.GetPagedLatestNewsByCategoryUrlAsync(categoryUrl, numberOfPosts, 2).Result.Any();
            ViewBag.Url = categoryUrl;
            return View();
        }
    }
}