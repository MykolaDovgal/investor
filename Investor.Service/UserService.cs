using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using Investor.Entity;
using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Investor.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User user)
        {
            var userEntity = Mapper.Map<User, UserEntity>(user);
            return await _userManager.CreateAsync(userEntity, user.Password);
        }
          
        public async Task SignInUserAsync(User user, bool isLongTime)
        {
            var userEntity = Mapper.Map<User, UserEntity>(user);
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

        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
