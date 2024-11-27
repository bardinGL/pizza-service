using Microsoft.EntityFrameworkCore.Diagnostics;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Order : EntityAuditBase<Guid>
    {
        public virtual ICollection<OrderItem> Items { get; set; }
        public Guid PaymentId { get; set; }
        public Guid FeedbackId { get; set; }
        public Guid OrderVoucherId { get; set; }
        public Guid OrderInTableId { get; set; }
        public Guid ProductId { get; set; }

        public virtual OrderInTable OrderInTable { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual FeedBack FeedBack { get; set; }
        public virtual OrderVoucher OrderVoucher { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        private Order() { }

        public Order(Guid id , Guid paymentId, Guid feedbackId, Guid ordervoucherId, Guid orderintableId, Guid productId)
        {
            Id = id;
            PaymentId = paymentId;
            FeedbackId = feedbackId;
            OrderVoucherId = ordervoucherId;
            OrderInTableId = orderintableId;
            ProductId = productId;
        }
    }
}
