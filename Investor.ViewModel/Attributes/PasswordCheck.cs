using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Investor.Service;
using Investor.Service.Interfaces;

namespace Investor.ViewModel.Attributes
{
    public class PasswordCheck : ValidationAttribute
    {
        private IUserService _userService;

        public PasswordCheck()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _userService = (IUserService)validationContext
                .GetService(typeof(IUserService));
            if (_userService != null && _userService.PasswordCheck((string) value).Result)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("A password is required");
        }
    }
}
