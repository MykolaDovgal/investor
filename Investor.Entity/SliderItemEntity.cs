using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Entity
{
    public class SliderItemEntity
    {
        [Key]
        public int SliderItemId { set; get; }
        public int PostId { set; get; }
        public PostEntity Post { set; get; }
        public bool IsOnSlider { set; get; }
        public bool IsOnSide { set; get; }
    }
}
