using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    public class ArticleEntity
    {
        [Key]
        public int ArticleId { get; set; }
        public string Context { get; set; }
    }
}
