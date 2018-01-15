using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class Account : Controller
    {
        private readonly IUserService _userService;
        public Account(IUserService userService)
        {
            _userService = userService;
        }
        [Route("checkNickname")]
        [HttpPost]
        public async Task<JsonResult> GetNicknames(string nickname)
        {
            var user = await _userService.GetUserByNickName(nickname);
            bool isValid = user == null;
            return new JsonResult(new {valid= isValid, message="Такий нікнейм вже існує"});
        }
        [Route("checkEmail")]
        [HttpPost]
        public async Task<JsonResult> GetEmails(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            bool isValid = user == null;
            return new JsonResult(new { valid = isValid, message = "Користувач з таким email-ом вже існує" });
        }
    }
}
