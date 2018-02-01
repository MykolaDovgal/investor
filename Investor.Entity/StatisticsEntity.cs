using System;
using System.ComponentModel.DataAnnotations;

namespace Investor.Entity
{
    public class StatisticsEntity
    {
        [Key]
        public int StatisticsId { set; get; }
        public int PostId { set; get; }
        public PostEntity Post { set; get; }
        public string ClientIp { set; get; }
        public DateTime Date { set; get; }
    }
}
