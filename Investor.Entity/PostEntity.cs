using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        [MaxLength(20000)]
        [StringLength(20000)]
        public string Article { set; get; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { set; get; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { set; get; }

        [DataType(DataType.DateTime)]
        public DateTime? PublishedOn { set; get; }

        public bool? IsPublished { set; get; }

        public int? CategoryId { set; get; }
        public CategoryEntity Category { set; get; }

        public List<PostTagEntity> PostTags { get; set; }
        //public List<ClientPostEntity> ClientVisits { set; get; }

        public PostEntity()
        {
            PostTags = new List<PostTagEntity>();
            //ClientVisits = new List<ClientPostEntity>();
            Category = null;
        }
    }
}
