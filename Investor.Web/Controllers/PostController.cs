﻿using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Investor.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        } 
        public IActionResult Index(int id)
        {
            Post post = _postService.GetPostByIdAsync(id).Result;
            ViewBag.Post = post;
            return View("Index");
        }
    }
}
