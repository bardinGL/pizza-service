using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderVoucher : EntityAuditBase<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid VoucherId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Voucher Voucher { get; set; }


        private OrderVoucher() { }

        public OrderVoucher(Guid id ,Guid orderId, Guid voucherId)
        {
            Id = id;
            OrderId = orderId;
            VoucherId = voucherId;
        }
    }
}
