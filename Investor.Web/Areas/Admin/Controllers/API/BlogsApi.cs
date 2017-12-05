using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Areas.Admin.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BlogsApi : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;
        private readonly IImageService _imageService;


        public BlogsApi(IBlogService blogService, ICategoryService categoryService, IImageService imageService)
        {

            _blogService = blogService;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        [Route("GetAllBlogs")]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            IEnumerable<TableBlogPreview> result = await _blogService.GetAllBlogsAsync<TableBlogPreview>();
            return Json(new { data = result });
        }

        [Route("UpdateBlog")]
        [HttpPost]
        public JsonResult UpdateBlog([FromForm]Blog post, [FromForm]IFormFile image)
        {
            post.Image = image != null ? _imageService.SaveImage(image) : null;
            _blogService.AddTagsToBlogAsync(post.PostId, post.Tags?.Select(s => s.Name)).Wait();
            post.Category = _categoryService.GetCategoryByUrlAsync("blog").Result;
            return Json(new { id = _blogService.UpdateBlogAsync(post).Result.PostId });
        }


        [Route("UpdateTableBlogs")]
        [HttpPost]
        public async Task UpdateTableBlogs(List<Blog> content)
        {
            await _blogService.UpdateBlogAsync<Blog>(content);
        }

        [Route("DeleteBlog")]
        [HttpPost]
        public async Task<JsonResult> DeleteBlog(List<int> id)
        {
            await _blogService.RemoveBlogAsync(id);
            return Json(new { success = true });
        }
    }
}
