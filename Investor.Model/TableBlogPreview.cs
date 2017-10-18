using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class TableBlogPreview
    {
        public int BlogId { set; get; }
        public string Title { set; get; }
        public DateTime CreatedOn { set; get; }
        public User Author { set; get; }
        public bool? IsPublished { set; get; }
    }
}
