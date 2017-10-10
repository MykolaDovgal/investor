using System;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [Route("posts")]
        [HttpGet]
        public async Task<IActionResult> SearchPosts(string categoryUrl, string query, DateTime date, int page, int count)
        {
            var postQuery = new PostSearchQuery { CategoryUrl = categoryUrl, Count = count, Date = date, Page = page, Query = query };
            var posts = await _searchService.SearchPosts(postQuery);
            return PartialView("~/Views/Search/_SearchResultTemplate.cshtml", posts);
        }
    }
}

