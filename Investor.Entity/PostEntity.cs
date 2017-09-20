using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    public class PostEntity
    {
        [Key]
        public int PostId { set; get; }

        [MaxLength(100)]
        [StringLength(100)]
        public string Title { set; get; }

        [MaxLength(500)]
        [StringLength(500)]
        public string Description { set; get; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Image { set; get; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { set; get; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { set; get; }
        [DataType(DataType.DateTime)]
        public DateTime? PublishedOn { set; get; }

        public bool? IsPublished { set; get; }
        public bool? IsOnMainPage { set; get; }
        public bool? IsImportant { set; get; }

        public int CategoryId { set; get; }
        public CategoryEntity Category { set; get; }

        public int ArticleId { set; get; }
        public ArticleEntity Article { set; get; }

        public string AuthorId { set; get; }
        [ForeignKey("AuthorId")]
        public UserEntity Author { set; get; }

        public List<PostTagEntity> PostTags { get; set; }
        public IList<CommentEntity> Comments { set; get; }

        public PostEntity()
        {
            PostTags = new List<PostTagEntity>();
            Comments = new List<CommentEntity>();
        }
    }
}
