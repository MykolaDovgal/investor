using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    [Table("Categories")]
    class CategoryEntity
    {
        public int CategoryId { set; get; }
        public string Name { set; get; }
        public string Url { set; get; }

        public IList<PostEntity> Posts { get; set; }

        public CategoryEntity()
        {
            Posts = new List<PostEntity>();
        }
    }
}
