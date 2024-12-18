using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Feedbacks
{
	public class GetListFeedbackIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public int? Rating { get; set; }
		public string? Comments { get; set; }
		public Guid? OrderId { get; set; }
	}
}
