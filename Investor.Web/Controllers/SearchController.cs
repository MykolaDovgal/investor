using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPostService _postService;

        public SearchController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            ViewBag.SearchResult = _postService.GetLatestPostsAsync(5).Result.ToList();
            return View();
        }
    }
}