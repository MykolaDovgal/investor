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
        private readonly ITagService _tagService;

        public ContentController(IPostService postService, ITagService tagService)
        {
            _postService = postService;
            _tagService = tagService;
        }

        [Route("GetAllNews")]
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _postService.GetAllPostsAsync<TablePostPreview>();
            return Json(new {data = result });
        }

        [Route("UpdateNews")]
        [HttpPost]
        public JsonResult UpdateNews()
        {            
            return Json(new { data = "ok" });
        }
        
        [Route("GetAllTags")]
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _tagService.GetAllTagsAsync();
            return Json(new { data = result });
        }
    }
}