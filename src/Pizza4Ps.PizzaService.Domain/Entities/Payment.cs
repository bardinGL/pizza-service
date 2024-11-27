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
        public decimal Amount { get; set; }
        
        public PaymentMethodTypeEnum PaymentMethod { get; set; } = PaymentMethodTypeEnum.Cash;
        public PaymentTypeEnum PaymentStatus {  get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Payment() { }
        public Payment(Guid id ,string name, PaymentMethodTypeEnum paymentMethos, decimal amount, PaymentTypeEnum paymentStatus)
        {
            Id = id;
            Name = name;
            PaymentMethod = paymentMethos;
            Amount = amount;
            PaymentStatus = paymentStatus;
        }
    }
}
