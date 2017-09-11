using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Investor.Entity
{
    public class PostTagEntity
    {
        [Key]
        public int PostTagId { get; set; }

        public int TagId { get; set; }

        public int PostId { get; set; }

        public TagEntity Tag { get; set; }

        public PostEntity Post { get; set; }
    }
}
