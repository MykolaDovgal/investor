using System.Threading.Tasks;
using Investor.Model.Views;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Authorize(AuthenticationSchemes = "backend")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            //bool isAuthenticated = User.Identity.IsAuthenticated;
            //if (isAuthenticated)
            //{
            //    return View("~/Areas/Admin/Views/Home/Index.cshtml");
            //}
            //else
            //{
            //    return View("Login");
            //}
            return View();
        }
    }
}
