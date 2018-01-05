using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Investor.Service.Utils;
using Investor.Web.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;

namespace Investor.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly INewsService _postService;
        private readonly ITagService _tagService;
        private readonly IpService _ipService;

        public PostController(INewsService postService, ITagService tagService, IpService ipService)
        {
            _postService = postService;
            _tagService = tagService;
            _ipService = ipService;
        }

        [ServiceFilter(typeof(HitCount))]
        public IActionResult Index(int id)
        {
            ViewBag.PathBase = Request.Host.Value;
            News post = _postService.GetNewsByIdAsync(id).Result;

            if (!(post?.IsPublished) ?? true)
            {
                Response.StatusCode = 403;
                return StatusCode(Response.StatusCode);
            }
            ViewBag.Post = post;
            ViewBag.LatestPosts = _postService.GetLatestNewsAsync(10).Result?.ToList();
            ViewBag.ImportantPosts = _postService.GetImportantNewsAsync(10).Result?.ToList();
            ViewBag.Tags = _postService.GetAllTagsByNewsIdAsync(id).Result?.ToList();
            ViewBag.PopularTags = _tagService.GetPopularTagsAsync(5).Result?.ToList();

            
            if (HttpContext.Session.Keys.Contains("count"))
            {
                int? count = HttpContext.Session.GetInt32("count");
            }

            return View("Index");
        }

        public IActionResult LastNews()
        {
            IEnumerable<PostPreview> lastNews = _postService.GetLatestNewsAsync(10).Result.ToList();
            return View(lastNews);
        }

        

        

    }
}


