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

        public ContentController(IPostService postService, ISliderItemService sliderItemService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _sliderItemService = sliderItemService;
            _categoryService = categoryService;
            _tagService = tagService;
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
            return PartialView("SinglePost",post);
        }

        [HttpPost]
        public void UpdatePost( [Bind("PostId, Title, Description, Published, IsImportant, IsOnMainPage")]Post post, [FromForm] string[] Tags, bool IsOnSlider, bool IsOnSide)
        {
            if(post != null)
            {
                //if Post exists
                if(post.PostId != 0)
                {
                    if (Request.Form.Files[0].FileName != String.Empty)
                        post.Image = Request.Form.Files[0].FileName;

                    post.Article.Content = Request.Form["Article"].First();
                    post.Category = _categoryService.GetCategoryByUrlAsync(Request.Form["Category"].First()).Result;
                    if (ModelState.IsValid)
                        _postService.UpdatePostAsync(post);

                }
                else
                {
                    post.Article = new Article { Content = Request.Form["Article"].First() }; // не знаю чи заканає, мало би додавати до таблиці статей новий об'єкт
                    _postService.AddPostAsync(post);
                }

            }
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