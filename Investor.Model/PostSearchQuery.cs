using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Investor.Model
{
    public class PostSearchQuery
    {
        public string Query { get; set; }
        public string CategoryUrl { get; set; }
        public DateTime? Date { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }

        public PostSearchQuery()
        {
            Query = string.Empty;
            CategoryUrl = string.Empty;
            Date = null;
            Page = 1;
            Count = 10;
        }

    }
}
