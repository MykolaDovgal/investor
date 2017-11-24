using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Model;
using Investor.Model.Views;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Investor.Web.Controllers.UsersControllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly INewsService _postService;
        private readonly IImageService _imageService;

        public AccountController(IUserService userService,IBlogService blogService, IImageService imageService, INewsService postService)
        {
            _userService = userService;
            _postService = postService;
            _imageService = imageService;
            _blogService = blogService;
        }

        public IActionResult Profile(string id)
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.User = currentUser;

            ViewBag.IsOwner = currentUser != null && (String.IsNullOrWhiteSpace(id) && String.IsNullOrWhiteSpace(currentUser.Id) &&
                                                      id == currentUser.Id);
            return View();
        }
        public IActionResult Account(string id)
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.User = currentUser;
            ViewBag.IsOwner = currentUser != null && (String.IsNullOrWhiteSpace(id) && String.IsNullOrWhiteSpace(currentUser.Id) &&
                                                      id == currentUser.Id);
            var res = _blogService.GetBlogsByUserIdAsync(currentUser?.Id).Result;
            return View(res);
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
        public IActionResult CreatePost([FromForm] Blog blog, [FromForm]IFormFile image)
        {
            blog.Image = image != null ? _imageService.SaveImage(image) : null;
            var tmp = _blogService.AddBlogAsync(blog).Result;
            return Json(Url.Action("Account", "Account"));
        }

        [HttpPost]
        public IActionResult UpdatePost([FromForm] Blog blog, [FromForm]IFormFile image)
        {
            blog.Image = image != null ? _imageService.SaveImage(image) : null;
            var tmp = _blogService.UpdateBlogAsync(blog).Result;
            return Json(Url.Action("Account", "Account"));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, [FromForm]IFormFile Photo, [FromForm]List<int> Points)
        {
            var user = Mapper.Map<RegisterViewModel, User>(model);
            user.Photo = _imageService.SaveAccountImage(Photo, Points);

            if ((await _userService.CreateUserAsync(user)).Succeeded)
            {
                return View("Login");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result =
                await _userService.PasswordSignInUserAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _userService.SignOutUserAsync();
            return Json(Url.Action("Index", "Home"));
        }
    }
}