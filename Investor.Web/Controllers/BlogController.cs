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
        private readonly IPostService _postService;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;

        public BlogController(IPostService postService,IBlogService blogService,ICategoryService categoryService, IUserService userService, ITagService tagService)
        {
            _postService = postService;
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            ViewBag.IsBlog = true;
            ViewBag.PopularTags = _tagService.GetPopularTagsAsync(5).Result.ToList();
            ViewBag.LatestPosts = _postService.GetLatestPostsAsync(20).Result.ToList();
            ViewBag.LatestBlogs = _blogService.GetLatestBlogsAsync().Result.ToList();
            ViewBag.PopularBlogs = _blogService.GetPopularBlogsAsync().Result.ToList();
            ViewBag.Blogers = _userService.GetDictionaryOfBlogersAsync().Result;
            return View();
        }

        public IActionResult Page(int id)
        {
            ViewBag.PathBase = Request.Host.Value;
            ViewBag.Post = _blogService.GetPostByIdAsync(id).Result; ;
            ViewBag.LatestPosts = _postService.GetLatestPostsAsync(10).Result.ToList();           
            ViewBag.Tags = _postService.GetAllTagsByPostId(id).Result.ToList();
            return View("Single/BlogPage");
        }
    }
}