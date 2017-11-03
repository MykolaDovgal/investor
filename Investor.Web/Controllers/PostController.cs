using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Investor.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ITagService _tagService;
        public PostController(IPostService postService, ITagService tagService)
        {
            _postService = postService;
            _tagService = tagService;
        } 
        public IActionResult Index(int id)
        {
            ViewBag.PathBase = Request.Host.Value;
            ViewBag.Post = _postService.GetPostByIdAsync(id).Result; ;
            ViewBag.LatestPosts = _postService.GetLatestPostsAsync(10).Result.ToList();
            ViewBag.ImportantPosts = _postService.GetImportantPostsAsync(10).Result.ToList(); ;
            ViewBag.Tags = _postService.GetAllTagsByPostId(id).Result.ToList();
            ViewBag.PopularTags = _tagService.GetPopularTagsAsync(5).Result;
            return View("Index");
        }

        
    }
}
