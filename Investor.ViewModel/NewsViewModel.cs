using System.Collections.Generic;

namespace Investor.ViewModel
{
    public class NewsViewModel
    {
        public int PostId { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public string Article { set; get; }
        public bool IsPublished { set; get; }
        public bool IsOnMainPage { set; get; }
        public bool IsImportant { set; get; }
        public bool IsOnSlider { set; get; }
        public bool IsOnSide { set; get; }
        public string Category { set; get; }
        public List<string> Tags { get; set; }
    }
}
