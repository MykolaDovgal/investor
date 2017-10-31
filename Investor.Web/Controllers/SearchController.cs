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

        //[HttpGet]
        //public IActionResult PostsByTagName(string tag)
        //{
        //    ViewBag.TextQuery = tag;
        //    var postQuery = new PostSearchQuery { Query = tag };
        //    var searchResult = _searchService.SearchPosts
        //}
    }
}