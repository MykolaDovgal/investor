using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Investor.Model;

namespace Investor.Web.Controllers
{
    //[Authorize(Roles = "bloger")]
    public class BlogController : Controller
    { 
        private readonly IBlogService _blogService;
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;

        public BlogController(IBlogService blogService,ICategoryService categoryService, IUserService userService, ITagService tagService, INewsService newsService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
            _tagService = tagService;
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            ViewBag.IsBlog = true;
            ViewBag.PopularTags = _tagService.GetPopularTagsAsync(5).Result.ToList();
            ViewBag.PopularBlogers = _blogService.GetPopularUsers(10).Result.ToList(); ;
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(20).Result.ToList(); 
            ViewBag.LatestBlogs = _blogService.GetLatestBlogsAsync<BlogPreview>().Result.ToList();
            ViewBag.PopularBlogs = _blogService.GetPopularBlogsAsync().Result.ToList();
            ViewBag.Blogers = _userService.GetDictionaryOfBlogersAsync().Result;
            return View();
        }

        public IActionResult Page(int id)
        {
            ViewBag.PathBase = Request.Host.Value;
            var blogs = _blogService.GetBlogByIdAsync<Blog>(id).Result;
            ViewBag.Post = blogs;
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(10).Result.ToList();           
            ViewBag.Tags = _tagService.GetPopularTagsAsync(5).Result.ToList();
            return View("Single/BlogPage");
        }

        public IActionResult BlogerPage(string id)
        {
            User bloger = _userService.GetUserByNickName(id).Result;
            ViewBag.Blogs = _blogService.GetBlogsByUserIdAsync(bloger.Id).Result.ToList();
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(5).Result.ToList();
            ViewBag.IsBlog = true;
            return View("Bloger/BlogerPage", bloger);
        }
    }
}