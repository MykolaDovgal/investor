using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model.Views;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
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
            if (!await _userService.CheckUserForRole(model.Email, model.Password, "admin"))
            {
                ViewBag.Error = "У вас немає прав доступу!";
                return View(model);
            }
            var result = await _userService.PasswordSignInUserAsync(model.Email, model.Password, model.RememberMe, false);
            
            if (result.Succeeded)
            {
                return Redirect("/Admin");
            }
            ViewBag.Error = "Неправильний пароль!";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _userService.SignOutUserAsync();
            return Json(Url.Action("Index", "Home", new { area = "Admin" }));
        }
    }
}
