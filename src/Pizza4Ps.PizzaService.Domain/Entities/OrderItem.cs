using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderItem : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<OptionItemOrderItem> OptionItemOrderItems { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(string name, int quantity, decimal price, Guid orderId, Guid productId)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
