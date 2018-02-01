using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Model;
using Microsoft.AspNetCore.Identity;

namespace Investor.Service.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(User user, string userRole = "user");
        Task<bool> CheckUserForRole(string email, string password, string role);
        Task SignInUserAsync(User user, bool isLongTime, string schemeName = "default");
        Task<SignInResult> PasswordSignInUserAsync(string email, string password, bool rememberMe, bool isLongTime);
        Task SignOutUserAsync();
        Task<SortedDictionary<string, List<User>>> GetDictionaryOfBlogersAsync();
        Task<User> GetCurrentUserAsync();
        Task<User> GetUserById(string id);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<TableUserPreview>> GetTableUsersAsync();
        Task<User> GetUserByNickName(string id);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> ChangePasswordAsync(User user, string newPassword);
        Task<IEnumerable<T>> GetAllUsersAsync<T>();
        Task<IEnumerable<string>> GetAllRolesAsync();
        Task<string> GetRoleByUserAsync(string userId);
        Task SetUsersRole(string id, string role);
        Task<bool> PasswordCheck(string password);
    }
}
