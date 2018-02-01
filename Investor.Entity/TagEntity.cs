using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investor.Entity
{
    public class TagEntity
    {
        [Key]
        public int TagId { set; get; }

        [MaxLength(100)]
        [StringLength(100)]
        public string Name { set; get; }

        [MaxLength(100)]
        [StringLength(100)]
        public string Url { set; get; }

        public List<PostTagEntity> PostTags { get; set; }
        public TagEntity()
        {
            PostTags = new List<PostTagEntity>();
        }
    }
}
