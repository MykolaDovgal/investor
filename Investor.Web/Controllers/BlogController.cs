using System.Linq;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Investor.Model;
using Investor.Web.Filters;
using Microsoft.AspNetCore.Authorization;

namespace Investor.Web.Controllers
{
    //[Authorize(Roles = "bloger")]
    public class BlogController : Controller
    { 
        private readonly IBlogService _blogService;
        private readonly INewsService _newsService;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;

        public BlogController(IBlogService blogService, IUserService userService, ITagService tagService, INewsService newsService)
        {
            _blogService = blogService;
            _userService = userService;
            _tagService = tagService;
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            ViewBag.IsBlog = true;
            ViewBag.PopularTags = _tagService.GetPopularTagsAsync(5).Result.ToList();
            ViewBag.PopularBlogers = _blogService.GetPopularUsers(10).Result.ToList(); ;
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(20).Result.ToList(); 
            var latestBlogs = _blogService.GetLatestBlogsAsync<BlogPreview>().Result.ToList();
            ViewBag.LatestBlogs = latestBlogs;
            ViewBag.GetMoreEnabled = latestBlogs.Count == 10 &&
                                     _blogService.GetPagedLatestBlogsAsync(2, 10).Result.Any();
            ViewBag.PopularBlogs = _blogService.GetPopularBlogsAsync().Result.ToList();
            ViewBag.Blogers = _userService.GetDictionaryOfBlogersAsync().Result;
            return View();
        }

        [ServiceFilter(typeof(HitCount))]
        public IActionResult Page(int id)
        {
            ViewBag.PathBase = Request.Host.Value;
            var blogs = _blogService.GetBlogByIdAsync<Blog>(id).Result;
            ViewBag.Post = blogs;
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(10).Result.ToList();           
            ViewBag.Tags = _tagService.GetPopularTagsAsync(5).Result.ToList();
            return View("Single/BlogPage");
        }

        [Route("/unpublished/blog/{id}")]
        public IActionResult BlogPreview(int id)
        {
            User currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.PathBase = Request.Host.Value;
            var blog = _blogService.GetBlogByIdAsync<Blog>(id).Result;
            if (blog != null && ((!HttpContext.User.IsInRole("admin") && !HttpContext.User.IsInRole("bloger")) || blog.IsPublished ||
                                 (HttpContext.User.IsInRole("bloger") && currentUser.Id != blog.Author.Id)))
                return new StatusCodeResult(404);

            ViewBag.Post = blog;
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(10).Result.ToList();
            ViewBag.Tags = _tagService.GetPopularTagsAsync(5).Result.ToList();
            return View("Single/UnpublishedBlog");
        }

        public IActionResult BlogerPage(string id)
        {
            User bloger = _userService.GetUserByNickName(id).Result;
            ViewBag.Blogs = _blogService.GetBlogsByUserIdAsync(bloger.Id, true).Result.ToList();
            ViewBag.LatestPosts = _newsService.GetLatestNewsAsync(5).Result.ToList();
            ViewBag.IsBlog = true;
            return View("Bloger/BlogerPage", bloger);
        }
    }
}