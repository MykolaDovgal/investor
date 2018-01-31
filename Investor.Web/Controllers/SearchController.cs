using System;
using System.Linq;
using Investor.Model;
using Investor.Service.Interfaces;
using Investor.ViewModel;
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
            DateTime? dt = (DateTime?)null;
            if (!String.IsNullOrEmpty(date))
            {
                dt = DateTime.Parse(date);
            }
            var postQuery = new PostSearchQueryViewModel
            {
                CategoryUrl = categoryUrl,
                Count = count,
                Date = dt,
                Page = page,
                Query = query,
            };

            ViewBag.CategoryName = _categoryService.GetCategoryByUrlAsync(categoryUrl).Result;
            ViewBag.Query = postQuery;
            ViewBag.Date = dt?.Day + "." + dt?.Month + "." + dt?.Year;
            var searchResult = _searchService.SearchPosts(postQuery).Result.ToList();
            postQuery.Page++;
            ViewBag.GetMoreEnabled = searchResult.Count == postQuery.Count &&
                                     _searchService.SearchPosts(postQuery).Result.ToList().Count > 0;

            return View("Index", searchResult);
        }

        public IActionResult SearchByTag(string tag, string categoryUrl)
        {
            ViewBag.CategoryName = _categoryService.GetCategoryByUrlAsync(categoryUrl).Result;
            var postQuery = new PostSearchQueryViewModel { Tag = tag, CategoryUrl = categoryUrl };
            ViewBag.Query = postQuery;
            var searchResult = _searchService.SearchPosts(postQuery).Result.ToList();
            postQuery.Page++;
            ViewBag.GetMoreEnabled = searchResult.Count == postQuery.Count &&
                                     _searchService.SearchPosts(postQuery).Result.ToList().Count > 0;
            return View(searchResult);
        }
    }
}