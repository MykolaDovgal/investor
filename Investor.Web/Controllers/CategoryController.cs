using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investor.Service.Interfaces;

namespace Investor.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IPostService _postService;

        public CategoryController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}