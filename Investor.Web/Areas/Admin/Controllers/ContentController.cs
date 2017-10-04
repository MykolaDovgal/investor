using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        public IActionResult Blogs()
        {
            return PartialView("_Blogs");
        }

        public IActionResult Comments()
        {
            return PartialView("_Comments");
        }

        public IActionResult News()
        {
            return PartialView("_News");
        }
    }
}