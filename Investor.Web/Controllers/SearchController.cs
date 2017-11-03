using System.Linq;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet]
        public IActionResult Posts(string query)
        {
            ViewBag.TextQuery = query;
            var postQuery = new PostSearchQuery { Query = query };
            var searchResult = _searchService.SearchPosts(postQuery).Result.ToList();
            return View("Index", searchResult);
        }

        public IActionResult SearchByTag(string tag, bool IsBlog)
        {
            ViewBag.TagQuery = tag;
            ViewBag.IsBlog = IsBlog;
            var postQuery = new PostSearchQuery { Tag = tag, CategoryUrl = IsBlog ? "blog": ""};
            var searchResult = _searchService.SearchPosts(postQuery).Result.ToList();
            return View(searchResult);
        }
    }
}