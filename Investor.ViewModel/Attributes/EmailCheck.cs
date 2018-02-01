using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Investor.Service.Interfaces;

namespace Investor.ViewModel.Attributes
{
    public class EmailCheck : ValidationAttribute
    {
        private IUserService _userService;

        public EmailCheck()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _userService = (IUserService)validationContext
                .GetService(typeof(IUserService));

            var user = _userService?.GetUserByEmail((string)value).Result;
            bool isValid = user == null;

            if (_userService != null && isValid)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Такий email вже існує!");
        }
    }
}
