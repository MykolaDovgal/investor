using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Areas.Admin.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TagsApi : Controller
    {
        private readonly ITagService _tagService;

        public TagsApi(ITagService tagService)
        {
            _tagService = tagService;
        }
        [Route("GetAllTags")]
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            IEnumerable<AdminTag> result = await _tagService.GetAllTagsWithPostCountAsync();
            return Json(new { data = result });
        }

        [Route("UpdateTag")]
        [HttpPost]
        public async Task<Tag> UpdateTag(Tag tag)
        {
            Tag newTag = await _tagService.UpdateTagAsync(tag);
            return newTag;
        }

        [Route("CreateTag")]
        [HttpPost]
        public async Task<Tag> CreateTag(string name)
        {
            Tag newTag = await _tagService.AddTagAsync(new Tag { Name = name });
            return newTag;
        }

        [Route("RemoveTag")]
        [HttpPost]
        public async Task<JsonResult> RemoveTag(List<int> id)
        {
            await _tagService.RemoveTagAsync(id);
            return Json(new { success = true });

        }
    }
}
