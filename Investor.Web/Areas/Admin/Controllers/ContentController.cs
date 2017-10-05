using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        private readonly IPostService _postService;
        private readonly ISliderItemService _sliderItemService;
        private readonly ICategoryService _categoryService;

        public ContentController(IPostService postService, ISliderItemService sliderItemService, ICategoryService categoryService)
        {
            _postService = postService;
            _sliderItemService = sliderItemService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int id)
        {
            Post post = _postService.GetPostByIdAsync(id).Result;
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            List<SliderItem> sliderItems = _sliderItemService.GetAllSliderItemsAsync().Result.ToList();
            SliderItem sliderItem = sliderItems.FirstOrDefault(s => s.Post.PostId == id);
            ViewBag.IsOnSlider = sliderItem != null ? sliderItem.IsOnSlider : false;
            ViewBag.IsOnSide = sliderItem != null ? sliderItem.IsOnSide : false;
            return View(post);
        }
        public IActionResult Blogs()
        {
            return PartialView("_Blogs");
        }

        public IActionResult Comments()
        {
            return PartialView("_Comments");
        }

        public IActionResult News()
        {
            return PartialView("_News");
        }
    }
}