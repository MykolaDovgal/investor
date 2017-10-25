﻿using System.Threading.Tasks;
using AutoMapper;
using Investor.Model;
using Investor.Model.Views;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.UsersControllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBlogService _postService;

        public AccountController(IUserService userService,IBlogService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        public IActionResult MyProfile()
        {
            ViewBag.Header = "_AccountHeaderSection";
            return View();
        }
        public IActionResult MyAccount()
        {
            ViewBag.Header = "_AccountHeaderSection";

            return View(_postService.GetLatestBlogsAsync(5).Result);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = Mapper.Map<RegisterViewModel, User>(model);
            var result = await _userService.CreateUserAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _userService.SignOutUserAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}