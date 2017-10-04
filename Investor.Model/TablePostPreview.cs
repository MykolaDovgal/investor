using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class TablePostPreview
    {
        public int PostId { set; get; }
        public string Title { set; get; }
        public DateTime PublishedOn { set; get; }
        public Category Category { set; get; }
        public bool? IsPublished { set; get; }
        public bool? IsOnMainPage { set; get; }
        public bool? IsImportant { set; get; }
    }
}
