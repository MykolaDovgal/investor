using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Investor.Entity
{
    public class ClientEntity
    {
        [Key]
        public int ClidentId { set; get; }
        public string IP { set; get; }
        public List<ClientPostEntity> PostVisits { set; get; }

        public ClientEntity()
        {
            PostVisits = new List<ClientPostEntity>();
        }
    }
}
