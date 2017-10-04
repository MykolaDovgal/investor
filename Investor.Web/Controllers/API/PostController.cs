using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;
using Investor.Model;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("more")]
        [HttpGet]
        public async Task<IActionResult> GetMoreNews(string categoryUrl, int page, int limit)
        {
            var posts = await _postService.GetPagedLatestPostsByCategoryUrlAsync(categoryUrl, limit, page);
            return PartialView("~/Views/Category/_MoreNewsPostsTemplate.cshtml", posts as IEnumerable<PostPreview>); 
        }
    }
}