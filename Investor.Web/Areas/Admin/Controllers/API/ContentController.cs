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
        private readonly IImageService _imageService;

        public ContentController(IPostService postService, ITagService tagService, IBlogService blogService, ISliderItemService sliderItemService, ICategoryService categoryService, IImageService imageService)
        {
            _postService = postService;
            _tagService = tagService;
            _blogService = blogService;
            _categoryService = categoryService;
            _sliderItemService = sliderItemService;
            _imageService = imageService;
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
        public void UpdatePost([FromForm]Post post, [FromForm]SliderItem sliderItem, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            if (image != null)
            {
                post.Image = image.FileName;
                _imageService.SaveImage(image);
            }
            _postService.AddTagsToPostAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            Post newPost = _postService.GetPostByIdAsync(post.PostId).Result;
            newPost = Mapper.Map<Post, Post>(post, newPost);
            newPost.PublishedOn = !newPost.IsPublished && post.IsPublished ? DateTime.Now : post.PublishedOn;
            var tmp =_postService.UpdatePostAsync(newPost).Result;
            var newSliderItem = _sliderItemService.GetSliderItemByPostIdAsync(post.PostId).Result;
            if (newSliderItem != null)
            { 
                _sliderItemService.UpdateSliderItemAsync(Mapper.Map<SliderItem, SliderItem>(sliderItem, newSliderItem));
            }
            else if(sliderItem.IsOnSlider || sliderItem.IsOnSide)
            {
                _sliderItemService.AddSliderItemAsync(new SliderItem { Post = Mapper.Map<Post, PostPreview>(post), IsOnSide = sliderItem.IsOnSide, IsOnSlider = sliderItem.IsOnSlider });
            }
        }

        [Route("CreatePost")]
        [HttpPost]
        public void CreatePost([FromForm]Post post, [FromForm]SliderItem sliderItem, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            if (image != null)
            {
                post.Image = image.FileName;
                _imageService.SaveImage(image);
            }
            if (post.IsPublished)
            {
                post.PublishedOn = DateTime.Now;
            }
            var tmp = _postService.AddPostAsync(post).Result;
            _postService.AddTagsToPostAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            if (sliderItem.IsOnSlider || sliderItem.IsOnSide)
            {
                _sliderItemService.AddSliderItemAsync(new SliderItem { Post = Mapper.Map<Post, PostPreview>(post), IsOnSide = sliderItem.IsOnSide, IsOnSlider = sliderItem.IsOnSlider });
            }
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

        [Route("UpdateTablePost")]
        [HttpPost]
        public async Task UpdateTablePost(List<Post> tablePosts)
        {
            await _postService.UpdatePostAsync(tablePosts);
        }
    }
}