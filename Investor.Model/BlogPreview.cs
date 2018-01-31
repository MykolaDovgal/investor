using System;

namespace Investor.Model
{
    public class BlogPreview
    {
        public int PostId { set; get; }
        public string Url { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public bool IsPublished { set; get; }
        public DateTime PublishedOn { set; get; }
        public User Author { set; get; }
    }
}
