using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.DTOs.Feedbacks
{
	public class FeedbackDto
	{
		public Guid Id { get; set; }
		public int Rating { get; set; }
		public string Comments { get; set; }
		public Guid OrderId { get; set; }

		public virtual OrderDto Order { get; set; }
	}
}
