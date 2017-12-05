using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Areas.Admin.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersApi : Controller
    {
        private readonly IUserService _userService;

        public UsersApi(IUserService userService)
        {
            _userService = userService;
        }
        
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<TableUserPreview> result = (await _userService.GetAllUsersAsync<TableUserPreview>()).ToList();
            IEnumerable<string> roles = await _userService.GetAllRolesAsync();
            for (var i = 0; i < result.Count; i++)
            {
                var role = await _userService.GetRoleByUserAsync(result[i].Id);
                result[i].Role = role;
                
            }
            return Json(new { data = new { result = result, roles = roles } }); ;
        }

        [Route("UpdateTableUsers")]
        [HttpPost]
        public async Task<JsonResult> UpdateTableUsers(List<TableUserPreview> tableUsers)
        {
            for (int i = 0; i < tableUsers.Count; i++)
            {
                await _userService.SetUsersRole(tableUsers[i].Id, tableUsers[i].Role);
            }
            return Json(new { success = true });

        }
    }
}