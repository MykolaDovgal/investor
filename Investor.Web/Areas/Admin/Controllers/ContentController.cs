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
            return PartialView("SinglePost", post);
        }

        [HttpPost]
        public void UpdatePost([Bind("PostId, Title, Description, IsOnMainPage, IsImportant, Published")]Post post, [FromForm] string[] Tags, [FromForm] bool IsOnSlider, [FromForm] bool IsOnSide)
        {
            Post newPost; 
                
            if(post.PostId < 0)
            {
                newPost = _postService.GetPostByIdAsync(post.PostId).Result;
                newPost.IsOnMainPage = post.IsOnMainPage;
                newPost.IsImportant = post.IsImportant;
                newPost.Published = post.Published;
                newPost.Title = post.Title;
                newPost.Description = post.Description;
            }
            else
            { 
                newPost = _postService.AddPostAsync(post).Result;
            }

            //Image
            if (Request.Form.Files[0].FileName != String.Empty)
                newPost.Image = Request.Form.Files[0].FileName;

            //Category
            newPost.Category = _categoryService.GetCategoryByUrlAsync(Request.Form["Category"].First()).Result;

            //Tags
            List<Tag> allTags = _tagService.GetAllTagsAsync().Result.ToList();
            List<Tag> postTags = _postService.GetAllTagsByPostId(post.PostId).Result.ToList();

            for (int i = 0; i < Tags.Length; i++)
            {
                Tag tag = allTags.FirstOrDefault(s => s.Name.Equals(Tags[i]));

                if (tag == null)
                    tag = _tagService.AddTagAsync(new Tag { Name = Tags[i] }).Result;

                if ((postTags.Find(t=>t.TagId == tag.TagId) == null))
                    _postService.AddTagToPostAsync(newPost.PostId, Tags[i]);
            }

            //Article
            if (newPost.Article != null)
                newPost.Article = new Article { Content = Request.Form["Article"].First() };
            else
                newPost.Article.Content = Request.Form["Article"].First();

            _postService.UpdatePostAsync(newPost);
            //}
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