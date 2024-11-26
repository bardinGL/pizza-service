using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderItem : EntityAuditBase<Guid>
    {
        public int OrderNumber { get; set; }
        
        public Guid ProductId { get; set; }
        public virtual ICollection<OrderItemOption> OrderItemOptions { get; set; }
        public virtual Product Product { get; set; }
        private OrderItem() { }
        public OrderItem(Guid id, int orderNumber) {   
            Id = id;
            OrderNumber = orderNumber;

        }
    }
}
