using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    [Table("Categories")]
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { set; get; }

        [MaxLength(100)]
        public string Name { set; get; }

        [MaxLength(100)]
        public string Url { set; get; }

        public IList<PostEntity> Posts { get; set; }

        public CategoryEntity()
        {
            Posts = new List<PostEntity>();
        }
    }
}
