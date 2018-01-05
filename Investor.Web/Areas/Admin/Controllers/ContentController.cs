using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        private readonly INewsService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IBlogService _blogService;

        public ContentController(INewsService postService,  ICategoryService categoryService, ITagService tagService, IBlogService blogService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _blogService = blogService;
        }
        [Route("admin/post/{id}")]
        public IActionResult SinglePost(int id)
        {
            News post = _postService.GetNewsByIdAsync(id).Result;
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            ViewBag.Tags = _postService.GetAllTagsByNewsIdAsync(id).Result.ToList();
            return PartialView("SinglePost", post);
        }
        [Route("admin/blog/{id}")]
        public IActionResult SingleBlog(int id)
        {
            Blog blog = _blogService.GetBlogByIdAsync<Blog>(id).Result;
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            ViewBag.Tags = _postService.GetAllTagsByNewsIdAsync(id).Result.ToList();
            return PartialView("SingleBlog", blog);
        }
        [Route("admin/createpost")]
        public IActionResult CreateNews()
        {
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync().Result.ToList();
            return PartialView("SinglePost");
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
        public IActionResult Users()
        {
            return PartialView("_Users");
        }
    }
}