using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class SliderItem
    {
        public int SliderItemId { set; get; }
        public PostPreview Post { set; get; }
        public bool IsOnSlider { set; get; }
        public bool IsOnSide { set; get; }
    }
}
