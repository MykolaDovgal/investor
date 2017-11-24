using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model.Views
{
    public class PopularUserViewModel
    {
        public User User { set; get; }
        public int PostId { set; get; }
        public string Title { set; get; }
        public int NumberOfPosts { set; get; }
    }
}
