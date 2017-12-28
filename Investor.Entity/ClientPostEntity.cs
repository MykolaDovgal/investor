using System;
using System.Collections.Generic;
using System.Text;

namespace Investor.Entity
{
    public class ClientPostEntity
    {
        public int ClientId { set; get; }
        public int PostId { set; get; }
        public ClientEntity Client { set; get; }
        public PostEntity Post { set; get; }
        public DateTime Date { set; get; }
    }
}
