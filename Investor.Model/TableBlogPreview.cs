using System;

namespace Investor.Model
{
    public class TableBlogPreview
    {
        public int PostId { set; get; }
        public string Title { set; get; }
        public string Url { set; get; }
        public DateTime CreatedOn { set; get; }
        public User Author { set; get; }
        public bool? IsPublished { set; get; }
    }
}
