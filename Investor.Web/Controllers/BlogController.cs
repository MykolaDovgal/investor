using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers
{
    public class BlogController : Controller
    {

        private readonly IPostService _postService;
        private readonly IBlogService _blogService;

        public BlogController(IPostService postService,IBlogService blogService)
        {
            _postService = postService;
            _blogService = blogService;
        }

        public IActionResult Index(string[] arr)
        {
            ViewBag.LatestPosts = _postService.GetLatestPostsAsync(20).Result.ToList();
            ViewBag.LatestBlogs = _blogService.GetLatestBlogsAsync().Result.ToList();
            ViewBag.PopularBlogs = _blogService.GetPopularBlogsAsync().Result.ToList();
            return View();
        }
    }
}