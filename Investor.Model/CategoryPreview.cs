using System.Collections.Generic;

namespace Investor.Model
{
    public class CategoryPreview
    {
        public IEnumerable<PostPreview> LargePostPreviewTemplate;
        public IEnumerable<PostPreview> SmallPostPreviewTemplate;
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }


    }
}
