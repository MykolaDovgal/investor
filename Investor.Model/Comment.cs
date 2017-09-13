using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class Comment
    {
        public int CommentId { set; get; }
        public string Text { set; get; }
        public bool Pubished { set; get; }
        public DateTime PublishedOn { set; get; }
        public DateTime CreatedOn { set; get; }
        public int UserId { set; get; }    
        public int PostId { set; get; }
    }
}
