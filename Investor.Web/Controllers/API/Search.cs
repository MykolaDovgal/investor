using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class Search : Controller
    {
        private readonly ISearchService _searchService;

        public Search(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [Route("posts")]
        [HttpGet]
        public async Task<IActionResult> SearchPosts(int page,  int count, string tag = null, string categoryUrl = null, string query = null, string date = null)
        {
            DateTime? dt = null;
            if (!string.IsNullOrEmpty(date))
            {
                dt = DateTime.Parse(date);
            }
            PostSearchQuery postQuery = new PostSearchQuery
            {
                CategoryUrl = categoryUrl,
                Count = count,
                Date = dt,
                Page = page,
                Query = query,
                Tag = tag
            };

            IEnumerable<PostPreview> posts = await _searchService.SearchPosts(postQuery);
            return PartialView("~/Views/Search/_SearchResultTemplate.cshtml", posts);
        }
    }
}

