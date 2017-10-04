using System;
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
    public class ContentController : Controller
    {
        private readonly IPostService _postService;

        public ContentController(IPostService postService)
        {
            _postService = postService;
        }


        [Route("more")]
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _postService.GetAllPostsAsync<TablePostPreview>();
            return Json(new {data = result });
        }
    }
}