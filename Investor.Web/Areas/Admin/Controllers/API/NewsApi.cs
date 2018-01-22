using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Model;
using Investor.Model.Views;
using Investor.Service.Interfaces;
using Investor.Service.Utils.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Areas.Admin.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NewsApi : Controller
    {
        private readonly INewsService _newsService;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;

        public NewsApi(INewsService newsService, IImageService imageService, ICategoryService categoryService)
        {
            _newsService = newsService;
            _imageService = imageService;
            _categoryService = categoryService;
        }

        [Route("GetAllNews")]
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            IEnumerable<TablePostPreview> result = await _newsService.GetAllNewsAsync<TablePostPreview>();
            return Json(new { data = result });
        }

        [Route("UpdateNews")]
        [HttpPost]
        public JsonResult UpdatePost([FromForm]NewsViewModel post, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            _newsService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            //NewsViewModel newPost = Mapper.Map<News, NewsViewModel>(_newsService.GetNewsByIdAsync(post.PostId).Result);
            //newPost = Mapper.Map(post, newPost);
            var result =_newsService.UpdateNewsAsync(post).Result;
            return Json(new { id = result.PostId, href = $"{(result.IsPublished ? "" : "/unpublished" )}/post/{result.PostId}" });
        }

        [Route("CreateNews")]
        [HttpPost]
        public JsonResult CreateNews([FromForm]News post, [FromForm]IFormFile image)
        {
            post.Category = _categoryService.GetCategoryByUrlAsync(post.Category.Url).Result;
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            News tmp = _newsService.AddNewsAsync(post).Result;
            _newsService.AddTagsToNewsAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            return Json(new { id = tmp.PostId, href = $"{(tmp.IsPublished ? "" : "/unpublished")}/post/{tmp.PostId}" });
        }

        [Route("UpdateTableNews")]
        [HttpPost]
        public async Task<JsonResult> UpdateTableNews(List<News> content)
        {
            await _newsService.UpdateNewsAsync(content);
            return Json(new {success = true});
        }

        [Route("DeleteNews")]
        [HttpPost]
        public async Task<JsonResult> DeleteNews(List<int> id)
        {
            await _newsService.RemoveNewsAsync(id);
            return Json(new { success = true });
        }
    }
}
