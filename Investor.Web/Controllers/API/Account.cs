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
        [Route("nicknames")]
        [HttpGet]
        public async Task<IEnumerable<string>> GetNicknames()
        {
            var users = await  _userService.GetAllUsersAsync<TableUserPreview>();
            return users.Select(c => c.UserName);
        }
        [Route("emails")]
        [HttpGet]
        public async Task<IEnumerable<string>> GetEmails()
        {
            var users = await _userService.GetAllUsersAsync<TableUserPreview>();
            return users.Select(c => c.Email);
        }
    }
}
