using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OrderInTable : EntityAuditBase<Guid>
    {
        public string Status { get; set; }
        public Guid TableId { get; set; }

        public virtual Table Table { get; set; }

        private OrderInTable()
        {
        }

        public OrderInTable(Guid id, string status, Guid tableId)
        {
            Id = id;
            Status = status;
            TableId = tableId;
        }
    }
}
