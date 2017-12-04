using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class TableUserPreview
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public List<string> Socials { get; set; }
        public List<Blog> Blogs { set; get; }
    }
}
