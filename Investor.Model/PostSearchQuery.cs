using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investor.Model
{
    public class PostSearchQuery
    {
        public string Query { get; set; }
        public string CategoryUrl { get; set; }
        public DateTime? Date { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public string Tag { get; set; }

        public PostSearchQuery()
        {
            Query = string.Empty;
            CategoryUrl = string.Empty;
            Date = null;
            Page = 1;
            Count = 10;
            Tag = string.Empty;
        }

    }
}
