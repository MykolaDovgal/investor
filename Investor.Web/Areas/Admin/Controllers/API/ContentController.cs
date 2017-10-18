using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Investor.Web.Areas.Admin.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private readonly IPostService _postService;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;
        private readonly ISliderItemService _sliderItemService;
        private readonly IBlogService _blogService;

        public ContentController(IPostService postService, ITagService tagService, IBlogService blogService, ISliderItemService sliderItemService, ICategoryService categoryService)
        {
            _postService = postService;
            _tagService = tagService;
            _blogService = blogService;
            _categoryService = categoryService;
            _sliderItemService = sliderItemService;
        }

        [Route("GetAllNews")]
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _postService.GetAllPostsAsync<TablePostPreview>();
            return Json(new { data = result });
        }
        [Route("GetAllBlogs")]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _blogService.GetLatestBlogsAsync();
            return Json(new { data = result });
        }

        [Route("UpdateNews")]
        [HttpPost]
        public JsonResult UpdateNews()
        {
            return Json(new { data = "ok" });
        }


        [Route("UpdatePost")]
        [HttpPost]
        public void UpdatePost([Bind("PostId, Title, Description, IsOnMainPage, IsImportant, Published")]Post post, [FromForm] string[] Tags, [FromForm] bool IsOnSlider, [FromForm] bool IsOnSide)
        {
            Post newPost;

            if (post.PostId > 0)
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

                if ((postTags.Find(t => t.TagId == tag.TagId) == null))
                    _postService.AddTagToPostAsync(newPost.PostId, Tags[i]);
            }

            //Article
            if (newPost.Article != null)
                newPost.Article = new Article { Content = Request.Form["Article"].First() };
            else
                newPost.Article.Content = Request.Form["Article"].First();

            SliderItem sliderItem = _sliderItemService.GetSliderItemByPostIdAsync(newPost.PostId).Result;

            if (sliderItem != null)
            {
                sliderItem.IsOnSide = IsOnSide;
                sliderItem.IsOnSlider = IsOnSlider;
                _sliderItemService.UpdateSliderItemAsync(sliderItem);
            }
            else if (IsOnSlider && IsOnSide)
            {
                _sliderItemService.AddSliderItemAsync(new SliderItem { Post = Mapper.Map<Post, PostPreview>(newPost), IsOnSide = IsOnSide, IsOnSlider = IsOnSlider });
            }

            _postService.UpdatePostAsync(newPost);
            //}
        }

        [Route("GetAllTags")]
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _tagService.GetAllTagsWithPostCountAsync();
            return Json(new { data = result });
        }

        [Route("UpdateTag")]
        [HttpPost]
        public async Task<Tag> UpdateTag(Tag tag)
        {
            Tag newTag = await _tagService.UpdateTagAsync(tag);
            return newTag;
        }

        [Route("RemoveTag")]
        [HttpPost]
        public async Task RemoveTag(int TagId)
        {
            await _tagService.RemoveTagAsync(TagId);
        }
    }
}