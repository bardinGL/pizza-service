using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Payment : EntityAuditBase<Guid>
    {
        public string Name { get; set; } = "In Cash";
        
        public PaymentTypeEnum PaymentTypeEnum { get; set; } = PaymentTypeEnum.Cash;
        public virtual ICollection<Order> Orders { get; set; }
        public Payment() { }
        public Payment(Guid id ,string name, PaymentTypeEnum paymentTypeEnum)
        {
            Id = id;
            Name = name;
            PaymentTypeEnum = paymentTypeEnum;
        }
    }
}
