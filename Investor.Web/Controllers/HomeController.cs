using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;

namespace Investor.Web.Controllers
{
    //[Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;
        private readonly Dictionary<string, int> _postPreviewCount = new Dictionary<string, int>
        {
            { "policy", 8 },
            { "culture", 8 },
            { "economy", 4 },
            { "it", 4 },
            { "socium", 4 }
        };
        private readonly Dictionary<string, int>  _largePostPreviewCount = new Dictionary<string, int>
        {
            { "policy", 2 },
            { "culture", 2 },
            { "economy", 1 },
            { "it", 1 },
            { "socium", 1}
        };


        public HomeController(INewsService postService, 
            ICategoryService categoryService, 
             IBlogService blogService)
        {
            _newsService = postService;
            _categoryService = categoryService;
            _blogService = blogService;
        }
        
        public IActionResult Index()
        {
            List<CategoryPreview> news = new List<CategoryPreview>();
            List<Category> categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            categories.ForEach(category =>
            {
                List<PostPreview> categoryPosts = _newsService
                    .GetLatestNewsByCategoryUrlAsync(category.Url, true, _postPreviewCount[category.Url]).Result
                    .ToList();
                var largePostCount = _largePostPreviewCount[category.Url];
                news.Add(new CategoryPreview
                {
                    CategoryUrl = category.Url,
                    CategoryName = category.Name,
                    LargePostPreviewTemplate = categoryPosts.Take(largePostCount),
                    SmallPostPreviewTemplate = categoryPosts.Skip(largePostCount)
                });
            });

            ViewBag.SideNews = _newsService.GetSideNewsAsync(2).Result.ToList();

            ViewBag.SliderNews = _newsService.GetSliderNewsAsync(7).Result.ToList();

            ViewBag.News = news;
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(20).Result.ToList();

            List<BlogPreview> blogs = _blogService.GetLatestBlogsAsync<BlogPreview>(7).Result.ToList();

            ViewBag.Blogs = blogs;
            return View();
        }

    }
}
