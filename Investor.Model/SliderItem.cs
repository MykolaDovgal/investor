using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    class SliderItem
    {
        public int SliderItemId { set; get; }
        public Post Post { set; get; }
        public bool IsOnSlider { set; get; }
        public bool IsOnSide { set; get; }
    }
}
