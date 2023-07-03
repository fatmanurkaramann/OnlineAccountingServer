using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Domain.Abstractions
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime CretedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
