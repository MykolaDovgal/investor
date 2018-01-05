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
using System.IO;
using Investor.Service.Utils.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Investor.Web.Controllers.UsersControllers
{
    //[Authorize(Roles = "bloger, admin")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly INewsService _postService;
        private readonly IImageService _imageService;

        public AccountController(IUserService userService, IBlogService blogService, IImageService imageService, INewsService postService)
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
            return View(currentUser);
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.IsBlog = true;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, [FromForm]IFormFile Photo)
        {
            var user = Mapper.Map<RegisterViewModel, User>(model);
            user.Photo = _imageService.SaveAccountImage(Photo, model.CropPoints);

            if ((await _userService.CreateUserAsync(user)).Succeeded)
            {
                return Json(Url.Action("Login", "Account"));
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!await _userService.CheckUserForRole(model.Email, model.Password, "bloger"))
            {
                ViewBag.Error = "Ваш обліковий запис не створений або не активований!";
                return View(model);
            }
            var result = await _userService.PasswordSignInUserAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Неправильний пароль!";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _userService.SignOutUserAsync();
            return Json(Url.Action("Index", "Home"));
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