using System;
using System.Linq;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly ICategoryService _categoryService;

        public SearchController(ISearchService searchService, ICategoryService categoryService)
        {
            _searchService = searchService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Posts(int page = 1, int count = 10, string categoryUrl = null, string query = null, string date = null)
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
                Query = query,
            };

            ViewBag.CategoryName = _categoryService.GetCategoryByUrlAsync(categoryUrl).Result;
            ViewBag.Query = postQuery;
            var searchResult = _searchService.SearchPosts(postQuery).Result.ToList();

            return View("Index", searchResult);
        }

        public IActionResult SearchByTag(string tag, string categoryUrl)
        {
            ViewBag.CategoryName = _categoryService.GetCategoryByUrlAsync(categoryUrl).Result;
            var postQuery = new PostSearchQuery { Tag = tag, CategoryUrl = categoryUrl };
            ViewBag.Query = postQuery;
            var searchResult = _searchService.SearchPosts(postQuery).Result.ToList();
            return View(searchResult);
        }
    }
}