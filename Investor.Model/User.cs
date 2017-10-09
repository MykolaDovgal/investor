using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<string> Socials { get; set; }
    }
}
