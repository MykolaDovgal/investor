using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model.Views
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
