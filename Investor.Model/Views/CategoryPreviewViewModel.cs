using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model.Views
{
    public class CategoryPreviewViewModel
    {
        public IEnumerable<PostPreview> LargePostPreviewTemplate;
        public IEnumerable<PostPreview> SmallPostPreviewTemplate;
        public string CategoryName { get; set; }


    }
}
