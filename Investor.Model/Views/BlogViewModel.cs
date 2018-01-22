using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model.Views
{
    public class BlogViewModel
    {
        public int PostId { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public string Article { set; get; }
        public Category Category { set; get; }
        public bool IsPublished { set; get; }
        public User Author { set; get; }
        public List<Tag> Tags { get; set; }
    }
}
