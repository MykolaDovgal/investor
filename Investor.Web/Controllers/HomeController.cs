﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;
using Investor.Repository;
using Investor.Repository.Interfaces;
using Investor.Model.Views;
using Investor.Service;

namespace Investor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ThemeService _themeService;

        public HomeController(IPostService postService, ICategoryService categoryService, ThemeService themeService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _themeService = themeService;
        }

        public IActionResult Index()
        {
            List<CategoryPreviewViewModel> news = new List<CategoryPreviewViewModel>();
            List<Category> categories = _categoryService.GetAllCategoriesAsync().Result.ToList();

            categories.ForEach(category =>
            {
                var categoryPosts = _postService.GetAllByCategoryNameAsync(category.Name, true, _themeService.postPreviewCount[category.Name]).Result.ToList();
                int largePostCount = _themeService.largePostPreviewCount[category.Name];
                news.Add(new CategoryPreviewViewModel
                {
                    CategoryName = category.Name,
                    LargePostPreviewTemplate = categoryPosts.Take(largePostCount),
                    SmallPostPreviewTemplate = categoryPosts.Skip(largePostCount)                    
                });
            });

            ViewBag.News = news;        
            ViewBag.LatestPost = _postService.GetLatestPostsAsync(20).Result.ToList();
            return View();

        }

    }
}
