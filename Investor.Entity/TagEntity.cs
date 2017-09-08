using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    class TagEntity
    {
        public int TagId { set; get; }
        public string Name { set; get; }
        public string Url { set; get; }
 
        public IList <PostEntity> Posts { set; get; }
        public TagEntity()
        {
            Posts = new List<PostEntity>();
        }
    }
}
