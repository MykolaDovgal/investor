using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<string> Socials { get; set; }
        public List<int> CropPoints { get; set; }
    }
}
