namespace Pizza4Ps.PizzaService.Application.DTOs.Feedbacks
{
	public class UpdateFeedbackDto
	{
		public int Rating { get; set; }
		public string Comments { get; set; }
		public Guid OrderId { get; set; }
	}
}
