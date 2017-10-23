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
        public PostController(IPostService postService)
        {
            _postService = postService;
        } 
        public IActionResult Index(int id)
        {
            ViewBag.PathBase = Request.Host.Value;
            ViewBag.Post = _postService.GetPostByIdAsync(id).Result; ;
            ViewBag.LatestPosts = _postService.GetLatestPostsAsync(10).Result.ToList();
            ViewBag.ImportantPosts = _postService.GetImportantPostsAsync(10).Result.ToList(); ;
            ViewBag.Tags = _postService.GetAllTagsByPostId(id).Result.ToList();
            return View("Index");
        }

        
    }
}
