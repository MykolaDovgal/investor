using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;

namespace Investor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public HomeController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            IList<Category> categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            ViewBag.Categories = categories;
            ViewBag.Politics = _postService.GetAllByCategoryNameAsync(categories[0].Name, true).Result.ToList();
            ViewBag.Social   = _postService.GetAllByCategoryNameAsync(categories[1].Name, true).Result.ToList();
            ViewBag.Culture  = _postService.GetAllByCategoryNameAsync(categories[2].Name, true).Result.ToList();
            ViewBag.Economy  = _postService.GetAllByCategoryNameAsync(categories[3].Name, true).Result.ToList();
            return View();

        }

    }
}
