using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    class Post
    {
        public int PostId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public DateTime CreatedOn { set; get; }
        public DateTime ModifiedOn { set; get; }
        public DateTime PublishedOn { set; get; }
        public bool Published { set; get; }
        public bool IsOnMainPage { set; get; }
        public Category Category { set; get; }
        public Article Article { set; get; }
        public int AuthorId { set; get; }
        public List<Tag> Tags { get; set; }
        public IList<Comment> Comments { set; get; }

    }
}
