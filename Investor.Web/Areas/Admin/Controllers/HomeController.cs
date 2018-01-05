using System.Threading.Tasks;
using Investor.Model.Views;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminAuthorize")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("admin/StatusCode/{statusCode}")]
        public IActionResult AdminError(int statusCode)
        {
            return PartialView("Error", statusCode);
        }
    }
}
