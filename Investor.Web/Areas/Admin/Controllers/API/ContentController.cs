using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Net.Http;

namespace Investor.Web.Areas.Admin.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private readonly INewsService _postService;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;
        private readonly IImageService _imageService;

        public ContentController(INewsService postService, ITagService tagService, IBlogService blogService, ICategoryService categoryService, IImageService imageService)
        {
            _postService = postService;
            _tagService = tagService;
            _blogService = blogService;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        [Route("GetAllNews")]
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _postService.GetAllNewsAsync<TablePostPreview>();
            return Json(new { data = result });
        }
        [Route("GetAllBlogs")]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _blogService.GetLatestBlogsAsync<TableBlogPreview>();
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
        public JsonResult UpdatePost([FromForm]News post, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            _postService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            News newPost = _postService.GetNewsByIdAsync(post.PostId).Result;
            newPost = Mapper.Map(post, newPost);
            return Json(new { id = _postService.UpdateNewsAsync(newPost).Result.PostId });
        }

        [Route("UpdateBLog")]
        [HttpPost]
        public JsonResult UpdateBlog([FromForm]Blog post, [FromForm]IFormFile image)
        {
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            _postService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            post.Category = _categoryService.GetCategoryByUrlAsync("blog").Result;
            return Json(new { id = _blogService.UpdateBlogAsync(post).Result.PostId});
        }

        [Route("CreatePost")]
        [HttpPost]
        public JsonResult CreatePost([FromForm]News post, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            News tmp = _postService.AddNewsAsync(post).Result;
            _postService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            return Json(new { id = tmp.PostId });
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

        [Route("CreateTag")]
        [HttpPost]
        public async Task<Tag> CreateTag(string name)
        {
            Tag newTag = await _tagService.AddTagAsync(new Tag { Name = name});
            return newTag;
        }

        [Route("RemoveTag")]
        [HttpPost]
        public async Task<JsonResult> RemoveTag(List<int> id)
        {
            await _tagService.RemoveTagAsync(id);
            return Json(new { success = true });

        }

        [Route("UpdateTablePost")]
        [HttpPost]
        public async Task UpdateTablePost(List<News> tablePosts)
        {
            await _postService.UpdateNewsAsync(tablePosts);
        }

        [Route("UpdateTableBlogs")]
        [HttpPost]
        public async Task UpdateTableBlogs(List<Blog> tablePosts)
        {
            await _blogService.UpdateBlogAsync<Blog>(tablePosts);
        }

        [Route("DeletePosts")]
        [HttpPost]
        public async Task<JsonResult> DeletePosts(List<int> id)
        {
            await _postService.RemoveNewsAsync(id);
            return Json(new { success = true });
        }
    }
}