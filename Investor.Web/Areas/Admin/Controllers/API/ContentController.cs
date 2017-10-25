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
        public void UpdatePost([Bind("PostId, Title, Description, IsOnMainPage, IsImportant, Published")]Post post, [FromForm]string Article, [FromForm] string[] Tags, [FromForm] bool IsOnSlider, [FromForm] bool IsOnSide)
        {
            Post newPost = Mapper.Map<Post, Post>(post, _postService.GetPostByIdAsync(post.PostId).Result);
            if (Request.Form.Files[0].FileName != String.Empty)
                newPost.Image = Request.Form.Files[0].FileName;
            newPost.Category = _categoryService.GetCategoryByUrlAsync(Request.Form["Category"].First()).Result;
            newPost.Article.Content = Article;

            List<Tag> postTags = _postService.GetAllTagsByPostId(newPost.PostId).Result.ToList();
            Tags.ToList().ForEach (t => 
            {
                if ((postTags.Find(tg => tg.Name == t) == null))
                {
                    _postService.AddTagToPostAsync(newPost.PostId, t);
                }
            });

            var sliderItem = _sliderItemService.GetSliderItemByPostIdAsync(newPost.PostId).Result;
            if (_sliderItemService.GetSliderItemByPostIdAsync(newPost.PostId).Result != null)
            {
                _sliderItemService.UpdateSliderItemAsync(Mapper.Map<SliderItem, SliderItem>(new SliderItem { IsOnSide = IsOnSide, IsOnSlider = IsOnSlider }, sliderItem));
            }
            else if (IsOnSlider || IsOnSide)
            {
                _sliderItemService.AddSliderItemAsync(new SliderItem { Post = Mapper.Map<Post, PostPreview>(newPost), IsOnSide = IsOnSide, IsOnSlider = IsOnSlider });
            }

            _postService.UpdatePostAsync(newPost);
        }

        [Route("CreatePost")]
        [HttpPost]
        public void CreatePost([Bind("PostId, Title, Description, IsOnMainPage, IsImportant, Published")]Post post, [FromForm]string Article, [FromForm] string[] Tags, [FromForm] bool IsOnSlider, [FromForm] bool IsOnSide)
        {
            post.Image = Request.Form.Files[0].FileName;
            post.Category = _categoryService.GetCategoryByUrlAsync(Request.Form["Category"].First()).Result;
            post.Article = new Article() { Content = Article };
            Tags.ToList().ForEach(t => {
                _postService.AddTagToPostAsync(post.PostId, t);
            });
            post = _postService.AddPostAsync(post).Result;
            if (IsOnSlider || IsOnSide){
                _sliderItemService.AddSliderItemAsync(new SliderItem { Post = Mapper.Map<Post, PostPreview>(post), IsOnSide = IsOnSide, IsOnSlider = IsOnSlider });
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