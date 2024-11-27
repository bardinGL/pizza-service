using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderItem : EntityAuditBase<Guid>
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public virtual ICollection<OrderItemOption> OrderItemOptions { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

        private OrderItem() { }
        public OrderItem(Guid id, int quantity, decimal price, Guid productId, Guid orderId) {   
            Id = id;
            Quantity = quantity;
            ProductId = productId;
            OrderId = orderId;
        }
    }
}
