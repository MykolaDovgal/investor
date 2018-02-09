using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService, ICategoryService categoryService, IMapper mapper)
        {
            _searchService = searchService;
            _categoryService = categoryService;
            _mapper = mapper;
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
            PostSearchQuery postQuery = new PostSearchQuery { Tag = tag, CategoryUrl = categoryUrl };
            ViewBag.Query = postQuery;
            List<PostPreview> searchResult = _searchService.SearchPosts(postQuery).Result.ToList();
            postQuery.Page++;
            ViewBag.GetMoreEnabled = searchResult.Count == postQuery.Count &&
                                     _searchService.SearchPosts(postQuery).Result.ToList().Count > 0;
            return View(searchResult);
        }
    }
}