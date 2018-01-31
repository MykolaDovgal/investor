using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Investor.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _context;
        private readonly IMapper _mapper;

        public UserService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor context, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        private async Task<IdentityResult> CreateRoleAsync(string role)
        {
            if (!_roleManager.RoleExistsAsync(role).Result)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            var userEntity = _mapper.Map<User, UserEntity>(user, await _userManager.FindByIdAsync(user.Id));
            var userUpdateResult = await _userManager.UpdateAsync(userEntity);
            
            if (userUpdateResult.Succeeded)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string newPassword)
        {
            var userEntity = await _userManager.FindByIdAsync(user.Id);
            var result = await _userManager.ChangePasswordAsync(userEntity, user.Password, newPassword);
            if (result.Succeeded)
            {
                return IdentityResult.Success;
            }
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string userRole = "user")
        {
            var userEntity = _mapper.Map<User, UserEntity>(user);
            var userRegisterResult = await _userManager.CreateAsync(userEntity, user.Password);

            if (userRegisterResult.Succeeded && CreateRoleAsync(userRole).Result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userEntity, userRole);
                return IdentityResult.Success;
            }
            return IdentityResult.Failed();
        }

       

        public async Task SignInUserAsync(User user, bool isLongTime, string schemeName = "default")
        {
            var userEntity = _mapper.Map<User, UserEntity>(user);
            var schemes = (await _signInManager.GetExternalAuthenticationSchemesAsync()).Where(c=> c.Name == schemeName);
            await _signInManager.SignInAsync(userEntity, isLongTime);
        }

        public async Task<SignInResult> PasswordSignInUserAsync(string email, string password, bool rememberMe, bool isLongTime)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return await _signInManager.PasswordSignInAsync(user, password, rememberMe, isLongTime);
            }
            return SignInResult.Failed;
        }

        public async Task<bool> CheckUserForRole(string email, string password, string role)
        {
            UserEntity user = _userManager.Users.FirstOrDefault(c => c.Email == email);
            if (user != null)
            {
                return await _userManager.IsInRoleAsync(user, role);
            }
            return false;
        }

        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<SortedDictionary<string, List<User>>> GetDictionaryOfBlogersAsync()
        {
            SortedDictionary<string, List<User>> blogers = new SortedDictionary<string, List<User>>();
            List<UserEntity> users = (await _userManager.GetUsersInRoleAsync("bloger")).ToList();
            users.ForEach(u =>
            {
                if (blogers.ContainsKey(u.Surname[0].ToString()))
                {
                    blogers[u.Surname.Substring(0, 1)].Add(_mapper.Map<UserEntity, User>(u));
                }
                else
                {
                    blogers.Add(u.Surname[0].ToString(), new List<User>() { _mapper.Map<UserEntity, User>(u) });
                }
            }
            );
            return blogers;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(_context.HttpContext.User);
            return _mapper.Map<UserEntity, User>(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return _mapper.Map<UserEntity, User>(await _userManager.FindByEmailAsync(email));
        }

        public async Task<User> GetUserById(string id)
        {
            return _mapper.Map<UserEntity, User>(await _userManager.FindByIdAsync(id));
        }
        public async Task<User> GetUserByNickName(string nickName)
        {
            return _mapper.Map<UserEntity, User>(await _userManager.FindByNameAsync(nickName));
        }

        public async Task<IEnumerable<T>> GetAllUsersAsync<T>()
        {
            List<UserEntity> variable = await _userManager
                .Users
                .Include(c => c.Blogs)
                .ToListAsync();
            return variable
                .Select(_mapper.Map<UserEntity, T>);
        }
        public async Task<IEnumerable<string>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.Select(c => c.Name).ToListAsync();
        }

        public async Task<string> GetRoleByUserAsync(string userId)
        {
            string result = (await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(userId))).FirstOrDefault();
            return result;
        }

        public async Task<IEnumerable<TableUserPreview>> GetTableUsersAsync()
        {
            List<UserEntity> users = await _userManager
                .Users
                .Include(c => c.Blogs)
                .ToListAsync();
            List<TableUserPreview> result = users
                .Select(_mapper.Map<UserEntity, TableUserPreview>).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Role = (await _userManager.GetRolesAsync(users[i])).FirstOrDefault();
            }
            return result;
        }

        public async Task SetUsersRole(string id, string role)
        {
            UserEntity user = await _userManager.FindByIdAsync(id);
            string userRole = (await _userManager.GetRolesAsync(user)).ToList()[0];
            if (!userRole.Equals(role))
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                await _userManager.AddToRoleAsync(user, role);
            }
            
        }
    }
}
