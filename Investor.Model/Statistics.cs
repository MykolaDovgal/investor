using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Model
{
    public class Statistics
    {

        public int StatisticsId { set; get; }
        public int PostId { set; get; }
        public string ClientIp { set; get; }
        public DateTime Date { set; get; }
    }
}
