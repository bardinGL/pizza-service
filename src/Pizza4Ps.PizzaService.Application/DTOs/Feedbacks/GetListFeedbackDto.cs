using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Feedbacks
{
	public class GetListFeedbackDto : PaginatedRequestDto
	{
		public int? Rating { get; set; }
		public string? Comments { get; set; }
		public Guid? OrderId { get; set; }
	}
}
