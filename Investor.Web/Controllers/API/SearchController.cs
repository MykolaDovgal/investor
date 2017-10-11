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
        public async Task<IActionResult> SearchPosts(int page, int count, string categoryUrl = null, string query = null, string date = null)
        {
            DateTime? dt = null;
            if (!String.IsNullOrEmpty(date))
            {
                dt = DateTime.Parse(date);
            }
            var postQuery = new PostSearchQuery
            {
                CategoryUrl = categoryUrl,
                Count = count,
                Date = dt,
                Page = page,
                Query = query
            };

            var posts = await _searchService.SearchPosts(postQuery);
            return PartialView("~/Views/Search/_SearchResultTemplate.cshtml", posts);
        }
    }
}

