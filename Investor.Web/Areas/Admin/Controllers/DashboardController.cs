using System.Threading.Tasks;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminAuthorize")]
    public class DashboardController : Controller
    {
        [Route("admin/dashboard/")]
        public IActionResult Dashboard()
        {
            return PartialView("_Dashboard");
        }
        [HttpGet("admin/StatusCode/{statusCode}")]
        public IActionResult AdminError(int statusCode)
        {
            return PartialView("Error", statusCode);
        }
    }
}
