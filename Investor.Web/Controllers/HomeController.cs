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

namespace Investor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ISliderItemService _sliderItemService;


        public HomeController(IPostService postService, 
            ICategoryService categoryService, 
            ISliderItemService sliderItemService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _sliderItemService = sliderItemService;
        }

        public IActionResult Index()
        {
            IList<Category> categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            ViewBag.LatestPost = _postService.GetLatestPostsAsync(20).Result.ToList();
            ViewBag.Categories = categories;
            ViewBag.Politics = _postService.GetAllByCategoryNameAsync(categories[0].Name, true, 8).Result.ToList();
            ViewBag.Technologies = _postService.GetAllByCategoryNameAsync(categories[4].Name, true, 8).Result.ToList();
            ViewBag.Culture  = _postService.GetAllByCategoryNameAsync(categories[2].Name, true, 4).Result.ToList();
            ViewBag.Economy  = _postService.GetAllByCategoryNameAsync(categories[3].Name, true, 4).Result.ToList();
            SliderViewModel svm = new SliderViewModel()
            {
                SideItems = _sliderItemService.GetSideSliderItemsAsync().Result.ToList(),
                SliderItems = _sliderItemService.GetCentralSliderItemsAsync().Result.ToList()
            };
            ViewBag.SVM = svm;
            return View();
  
        }

    }
}
