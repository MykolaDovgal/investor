using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class PopularUser
    {
        public User User { set; get; }
        public int PostId { set; get; }
        public string Title { set; get; }
        public int NumberOfPosts { set; get; }
    }
}
