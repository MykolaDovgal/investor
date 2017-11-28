using System.Threading.Tasks;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class PostsPaginationController : Controller
    {

        private readonly INewsService _postService;
        private readonly IBlogService _blogService;

        public PostsPaginationController(INewsService postService, IBlogService blogService)
        {
            _postService = postService;
            _blogService = blogService;
        }

        [Route("more")]
        [HttpGet]
        public async Task<IActionResult> GetMoreNews(string categoryUrl, int page, int limit)
        {
            var posts = await _postService.GetPagedLatestNewsByCategoryUrlAsync(categoryUrl, limit, page);
            return PartialView("~/Views/Category/_MoreNewsPostsTemplate.cshtml", posts); 
        }

        [Route("morelastnews")]
        [HttpGet]
        public async Task<IActionResult> GetMoreLastNews(int page, int limit)
        {
            var posts = await _postService.GetPagedLatestNewsByCategoryUrlAsync("", limit, page);
            return PartialView("~/Views/Search/_SearchResultTemplate.cshtml", posts);
        }

        [Route("morelastblogs")]
        [HttpGet]
        public async Task<IActionResult> GetMoreLastBlogs(int page, int limit)
        {
            var posts = await _blogService.GetPagedLatestBlogsAsync(page, limit);
            return PartialView("~/Views/Blog/_LastBlogsTemplate.cshtml", posts);
        }
    }
}