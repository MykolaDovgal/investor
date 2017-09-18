using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model.Views
{
    public class CategoryPreviewViewModel
    {
        public IEnumerable<Post> LargePostPreviewTemplate;
        public IEnumerable<Post> SmallPostPreviewTemplate;
        public string CategoryName { get; set; }


    }
}
