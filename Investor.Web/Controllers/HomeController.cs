using System;
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
using Microsoft.AspNetCore.Authorization;
using UnidecodeSharpFork;

namespace Investor.Web.Controllers
{
    //[Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ISliderItemService _sliderItemService;
        private readonly ThemeService _themeService;


        public HomeController(IPostService postService, 
            ICategoryService categoryService, 
            ISliderItemService sliderItemService,
             ThemeService themeService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _themeService = themeService;
            _sliderItemService = sliderItemService;
        }

        public IActionResult Index()
        {
            List<CategoryPreviewViewModel> news = new List<CategoryPreviewViewModel>();
            List<Category> categories = _categoryService.GetAllCategoriesAsync().Result.ToList();

            categories.ForEach(category =>
            {
                var categoryPosts = _postService.GetLatestPostsByCategoryUrlAsync(category.Url, true, _themeService.postPreviewCount[category.Url]).Result.ToList();
                int largePostCount = _themeService.largePostPreviewCount[category.Url];
                news.Add(new CategoryPreviewViewModel
                {
                    CategoryUrl = category.Url,
                    CategoryName = category.Name,
                    LargePostPreviewTemplate = categoryPosts.Take(largePostCount),
                    SmallPostPreviewTemplate = categoryPosts.Skip(largePostCount)                    
                });
            });
            SliderViewModel svm = new SliderViewModel()
            {
                SideItems = _sliderItemService.GetSideSliderItemsAsync().Result.ToList(),
                SliderItems = _sliderItemService.GetCentralSliderItemsAsync().Result.ToList()
            };
            ViewBag.SVM = svm;
            ViewBag.News = news;        
            ViewBag.LatestPosts = _postService.GetLatestPostsAsync(20).Result.ToList();
            return View();
  
        }

    }
}
