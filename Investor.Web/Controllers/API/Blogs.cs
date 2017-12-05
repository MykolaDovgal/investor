using System.Linq;
using System.Threading.Tasks;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class Blogs : Controller
    {

        private readonly IBlogService _blogService;
        public Blogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Route("morelastblogs")]
        [HttpGet]
        public async Task<IActionResult> GetMoreLastBlogs(int page, int limit)
        {
            var posts = (await _blogService.GetPagedLatestBlogsAsync(page, limit)).ToList();
            return PartialView("~/Views/Blog/_LastBlogsTemplate.cshtml", posts);
        }
    }
}
