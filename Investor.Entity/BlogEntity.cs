using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Investor.Entity
{
    public class BlogEntity : PostEntity
    {
        public string AuthorId { set; get; }

        [ForeignKey("AuthorId")]
        public UserEntity Author { set; get; }

        public BlogEntity() : base() { }
    }
}
