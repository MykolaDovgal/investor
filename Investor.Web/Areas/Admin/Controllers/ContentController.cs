using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        private readonly IPostService _postService;
        private readonly ISliderItemService _sliderItemService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IBlogService _blogService;

        public ContentController(IPostService postService, ISliderItemService sliderItemService, ICategoryService categoryService, ITagService tagService, IBlogService blogService)
        {
            _postService = postService;
            _sliderItemService = sliderItemService;
            _categoryService = categoryService;
            _tagService = tagService;
            _blogService = blogService;
        }

        public IActionResult SinglePost(int id)
        {
            Post post = _postService.GetPostByIdAsync(id).Result;
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            List<SliderItem> sliderItems = _sliderItemService.GetAllSliderItemsAsync().Result.ToList();
            SliderItem sliderItem = sliderItems.FirstOrDefault(s => s.Post.PostId == id);
            ViewBag.IsOnSlider = sliderItem != null ? sliderItem.IsOnSlider : false;
            ViewBag.IsOnSide = sliderItem != null ? sliderItem.IsOnSide : false;
            ViewBag.Tags = _postService.GetAllTagsByPostId(id).Result.ToList();
            return PartialView("SinglePost", post);
        }

        public IActionResult SingleBlog(int id)
        {
            Blog blog = _blogService.GetPostByIdAsync(id).Result;
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            ViewBag.Tags = _postService.GetAllTagsByPostId(id).Result.ToList();
            return PartialView("SingleBlog", blog);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            Post post = new Post();
            return PartialView("SinglePost", post);
        }

        public IActionResult CreateBlog()
        {
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            Blog blog = new Blog();
            return PartialView("SingleBlog", blog);
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
        public IActionResult Tags()
        {
            return PartialView("_Tags");
        }
    }
}