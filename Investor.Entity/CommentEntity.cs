using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    class CommentEntity
    {
        [Key]
        public int CommentId { set; get; }

        public string Text { set; get; }
        public bool Pubished { set; get; }

        public DateTime PublishedOn { set; get; }
        public DateTime CreatedOn { set; get; }

        public int UserId { set; get; }
        public UserEntity User { set; get; }

        public int PostId { set; get; }
        public PostEntity Post { set; get; }
    }
}
