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
            List<TableUserPreview> result = (await _userService.GetTableUsersAsync()).ToList();
            IEnumerable<string> allRoles = await _userService.GetAllRolesAsync();
            return Json(new { data = new { result = result, roles = allRoles } }); ;
        }

        [Route("UpdateTableUsers")]
        [HttpPost]
        public async Task<JsonResult> UpdateTableUsers(List<TableUserPreview> content)
        {
            for (int i = 0; i < content.Count; i++)
            {
                await _userService.SetUsersRole(content[i].Id, content[i].Role);
            }
            return Json(new { success = true });

        }
    }
}