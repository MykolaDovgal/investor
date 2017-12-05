using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class News : Controller
    {

        private readonly INewsService _postService;

        public News(INewsService postService)
        {
            _postService = postService;
        }

        [Route("morenews")]
        [HttpGet]
        public async Task<IActionResult> GetMoreNews(string categoryUrl, int page, int limit)
        {
            IEnumerable<PostPreview> posts = await _postService.GetPagedLatestNewsByCategoryUrlAsync(categoryUrl, limit, page);
            return PartialView("~/Views/Category/_MoreNewsPostsTemplate.cshtml", posts); 
        }

        [Route("morelastnews")]
        [HttpGet]
        public async Task<IActionResult> GetMoreLastNews(int page, int limit)
        {
            IEnumerable<PostPreview> posts = await _postService.GetPagedLatestNewsByCategoryUrlAsync("", limit, page);
            return PartialView("~/Views/Search/_SearchResultTemplate.cshtml", posts);
        }        
    }
}