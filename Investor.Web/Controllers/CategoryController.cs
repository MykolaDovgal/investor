using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;

namespace Investor.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        public CategoryController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }
        public IActionResult Index(string url)
        {
            ViewBag.CategoryName = _categoryService.GetCategoryByUrlAsync(url).Result.Name;
            ViewBag.CategoryPopularPosts = _postService.GetPopularPostByCategoryUrlAsync(url, 5).Result.ToList() as IEnumerable<PostPreview>;
            ViewBag.CategoryPosts = _postService.GetLatestPostsByCategoryUrlAsync(url).Result.ToList() as IEnumerable<PostPreview>;
            ViewBag.LatestPosts = _postService.GetLatestPostsAsync(20).Result.ToList();

            return View();
        }
    }
}