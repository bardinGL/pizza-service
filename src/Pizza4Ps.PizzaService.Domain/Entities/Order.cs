using Microsoft.EntityFrameworkCore.Diagnostics;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Order : EntityAuditBase<Guid>
    {
        public virtual ICollection<OrderItem> Items { get; set; }
        public Guid PaymentId { get; set; }
        public Guid FeedbackId { get; set; }
        public Guid VoucherId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual FeedBack FeedBack { get; set; }
        public virtual Voucher Voucher { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        private Order() { }

        public Order(Guid id , Guid paymentId, Guid feedbackId, Guid voucherId)
        {
            Id = id;
            PaymentId = paymentId;
            FeedbackId = feedbackId;
            VoucherId = voucherId;
        }
    }
}
