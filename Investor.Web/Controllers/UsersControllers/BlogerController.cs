﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Investor.Service.Utils.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.UsersControllers
{
    [Authorize(Roles = "bloger")]
    public class BlogerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly IImageService _imageService;
        public BlogerController(IUserService userService, IBlogService blogService, IImageService imageService)
        {
            _userService = userService;
            _imageService = imageService;
            _blogService = blogService;
        }
        public IActionResult Profile()
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.User = currentUser;
            return View(currentUser);
        }
        public IActionResult Account()
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.User = currentUser;
            var res = _blogService.GetBlogsByUserIdAsync(currentUser?.Id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult CreatePost([FromForm] Blog blog, [FromForm]IFormFile image)
        {
            blog.Image = image != null ? _imageService.SaveImage(image) : null;
            blog.Author = _userService.GetCurrentUserAsync().Result;
            var tmp = _blogService.AddBlogAsync(blog).Result;
            return Json(Url.Action("Account", "Bloger"));
        }

        [HttpPost]
        public IActionResult UpdatePost([FromForm] Blog blog, [FromForm]IFormFile image)
        {
            blog.Image = image != null ? _imageService.SaveImage(image) : null;
            blog.Author = _userService.GetCurrentUserAsync().Result;
            var tmp = _blogService.UpdateBlogAsync(blog).Result;
            return Json(Url.Action("Account", "Bloger"));
        }

        public IActionResult CreatePost(string id)
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.User = currentUser;
            ViewBag.IsOwner = currentUser != null && (String.IsNullOrWhiteSpace(id) && String.IsNullOrWhiteSpace(currentUser.Id) &&
                                                      id == currentUser.Id);

            return View();
        }

        public IActionResult UpdatePost(int id)
        {
            ViewBag.Header = "_AccountHeaderSection";
            ViewBag.Tags = _blogService.GetAllTagsByBlogIdAsync(id).Result.ToList();
            var blog = _blogService.GetBlogByIdAsync<Blog>(id).Result;
            return View("CreatePost", blog);
        }

        [HttpPost]
        public async Task UpdateUser(User model, [FromForm]IFormFile Image, [FromForm]List<int> Points)
        {

            model.CropPoints = Points;
            model.Photo = Image != null ? _imageService.SaveAccountImage(Image, Points) : _imageService.CropExistingImage(Path.GetFileName(model.Photo), Points);
            await _userService.UpdateUserAsync(model);
        }

        [HttpPost]
        public async Task ChangePassword(User model, string newPassword)
        {
            await _userService.ChangePasswordAsync(model, newPassword);
        }
    }
}