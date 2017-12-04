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
        private readonly IUserService _userService;


        public ContentController(INewsService postService, ITagService tagService, IBlogService blogService, ICategoryService categoryService, IImageService imageService, IUserService userService)
        {
            _postService = postService;
            _tagService = tagService;
            _blogService = blogService;
            _categoryService = categoryService;
            _imageService = imageService;
            _userService = userService;
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
        public void UpdatePost([FromForm]News post, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            _postService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            News newPost = _postService.GetNewsByIdAsync(post.PostId).Result;
            newPost = Mapper.Map(post, newPost);
            _postService.UpdateNewsAsync(newPost).Wait();
        }

        [Route("UpdateBLog")]
        [HttpPost]
        public void UpdateBlog([FromForm]Blog post, [FromForm]IFormFile image)
        {
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            _postService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            post.Category = _categoryService.GetCategoryByUrlAsync("blog").Result;
            _blogService.UpdateBlogAsync(post).Wait();
        }

        [Route("CreatePost")]
        [HttpPost]
        public void CreatePost([FromForm]News post, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            var tmp = _postService.AddNewsAsync(post).Result;
            _postService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
        }

        [Route("GetAllTags")]
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _tagService.GetAllTagsWithPostCountAsync();
            return Json(new { data = result });
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = (await _userService.GetAllUsersAsync<TableUserPreview>()).ToList();
            var roles = await _userService.GetAllRolesAsync();
            for (int i = 0; i < result.Count; i++)
            {
                var role = await _userService.GetRoleByUserAsync(result[i].Id);
                result[i].Role = role;
                
            }
            var x = Json(new { data = new { result = result, roles = roles } });
            return x;
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

        [Route("UpdateTableUsers")]
        [HttpPost]
        public async Task<JsonResult> UpdateTableUsers(List<TableUserPreview> tableUsers)
        {
            for (int i = 0; i < tableUsers.Count; i++)
            {
                await _userService.SetUsersRole(tableUsers[i].Id, tableUsers[i].Role);
            }
            return Json(new { success = true });

        }

        //[Route("GetAllRoles")]
        //[HttpGet]
        //public async Task<IActionResult> GetAllRoles()
        //{
        //    var result = ;
        //    return Json(result);
        //}
    }
}