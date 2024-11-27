using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderInTable : EntityAuditBase<Guid>
    {
        public Guid TableID { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        private OrderInTable()
        {
        }

        public OrderInTable(Guid id, Guid tableId)
        {
            Id = id;
            TableID = tableId;
        }
    }
}
