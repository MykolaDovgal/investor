using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class Blog
    {
        public int PostId { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public DateTime CreatedOn { set; get; }
        public DateTime ModifiedOn { set; get; }
        public DateTime PublishedOn { set; get; }
        public bool Published { set; get; }
        public Article Article { set; get; }
        public User Author { set; get; }
        public List<Tag> Tags { get; set; }
    }
}
