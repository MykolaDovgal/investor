using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;
using Microsoft.AspNetCore.Identity;
using Investor.Model.Views;

namespace Investor.Service.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(User user, string userRole = "user");
        Task SignInUserAsync(User user, bool isLongTime);
        Task<SignInResult> PasswordSignInUserAsync(string email, string password, bool rememberMe, bool isLongTime);
        Task SignOutUserAsync();
        Task<SortedDictionary<string, List<User>>> GetDictionaryOfBlogersAsync();
        Task<User> GetCurrentUserAsync();
        Task<User> GetUserById(string id);
        Task<User> GetUserByNickName(string id);
    }
}
