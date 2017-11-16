using System.Threading.Tasks;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {

        private readonly INewsService _postService;

        public PostController(INewsService postService)
        {
            _postService = postService;
        }

        [Route("more")]
        [HttpGet]
        public async Task<IActionResult> GetMoreNews(string categoryUrl, int page, int limit)
        {
            var posts = await _postService.GetPagedLatestNewsByCategoryUrlAsync(categoryUrl, limit, page);
            return PartialView("~/Views/Category/_MoreNewsPostsTemplate.cshtml", posts); 
        }
    }
}