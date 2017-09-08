using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    class PostEntity
    {
        [Key]
        public int PostId { set; get; }

        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }

        public DateTime CreatedOn { set; get; }
        public DateTime ModifiedOn { set; get; }
        public DateTime PublishedOn { set; get; }

        public bool Published { set; get; }
        public bool IsOnMainPage { set; get; }

        public int CategoryId { set; get; }
        public CategoryEntity Category { set; get; }

        public int ArticleId { set; get; }
        public ArticleEntity Article { set; get; }

        public int AuthorId { set; get; }
        public UserEntity Author { set; get; }

        public IList<TagEntity> Tags { set; get; }
        public IList<CommentEntity> Comments { set; get; }

        public PostEntity()
        {
            Tags = new List<TagEntity>();
            Comments = new List<CommentEntity>();
        }
    }
}
