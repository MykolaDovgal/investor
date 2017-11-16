using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Investor.Entity
{
    [Table("PostTags")]
    public class PostTagEntity
    {
        public int TagId { get; set; }
        public int PostId { get; set; }
        public TagEntity Tag { get; set; }
        public PostEntity Post { get; set; }
    }
}
