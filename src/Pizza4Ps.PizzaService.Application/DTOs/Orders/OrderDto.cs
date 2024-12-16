using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.Orders
{
    public class OrderDto
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Status { get; set; }
        public Guid OrderInTableId { get; set; }

        public virtual OrderInTable OrderInTable { get; set; }
    }
}
