namespace Pizza4Ps.PizzaService.Application.DTOs.Orders
{
	public class UpdateOrderDto
	{
		public DateTimeOffset StartTime { get; set; }
		public DateTimeOffset EndTime { get; set; }
		public string Status { get; set; }
		public Guid TableId { get; set; }
	}
}
