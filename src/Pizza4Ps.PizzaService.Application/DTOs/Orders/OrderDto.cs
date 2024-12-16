using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.Orders
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public DateTimeOffset StartTime { get; set; }
		public DateTimeOffset EndTime { get; set; }
		public string Status { get; set; }
		public Guid TableId { get; set; }

		public virtual Table Table { get; set; }
	}
}
