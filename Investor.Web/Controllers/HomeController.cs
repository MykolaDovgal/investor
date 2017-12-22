using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;
using Investor.Repository;
using Investor.Repository.Interfaces;
using Investor.Model.Views;
using Investor.Service;
using Microsoft.AspNetCore.Authorization;
using UnidecodeSharpFork;

namespace Investor.Web.Controllers
{
    //[Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private readonly INewsService _postService;
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
            _postService = postService;
            _categoryService = categoryService;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            List<CategoryPreviewViewModel> news = new List<CategoryPreviewViewModel>();
            List<Category> categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            categories.ForEach(category =>
            {
                var categoryPosts = _postService.GetLatestNewsByCategoryUrlAsync(category.Url, true, _postPreviewCount[category.Url]).Result.ToList();
                int largePostCount = _largePostPreviewCount[category.Url];
                news.Add(new CategoryPreviewViewModel
                {
                    CategoryUrl = category.Url,
                    CategoryName = category.Name,
                    LargePostPreviewTemplate = categoryPosts.Take(largePostCount),
                    SmallPostPreviewTemplate = categoryPosts.Skip(largePostCount)                    
                });
            });
            ViewBag.SideNews = _postService.GetSideNewsAsync(2).Result.ToList();
            ViewBag.SliderNews = _postService.GetSliderNewsAsync(7).Result.ToList();
            ViewBag.News = news;        
            ViewBag.LatestPosts = _postService.GetLatestNewsAsync(20).Result.ToList();
            var blogs = _blogService.GetLatestBlogsAsync<BlogPreview>(7).Result.ToList();
            ViewBag.Blogs = blogs;
            return View();
        }
        [Route("Error")]
        public IActionResult Error(int code)
        {
            return RedirectToAction("Index");
        }

    }
}
