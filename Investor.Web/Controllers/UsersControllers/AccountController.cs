using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Investor.Service.Utils.Interfaces;
using Investor.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Investor.Web.Controllers.UsersControllers
{
    [Authorize(Roles = "bloger")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IImageService imageService, IMapper mapper)
        {
            _userService = userService;
            _imageService = imageService;
            _mapper = mapper;
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
            var user = _mapper.Map<RegisterViewModel, User>(model);
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

        
    }
}