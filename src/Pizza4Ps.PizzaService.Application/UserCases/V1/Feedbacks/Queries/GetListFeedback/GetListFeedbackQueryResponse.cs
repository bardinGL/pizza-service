using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedback
{
	public class GetListFeedbackQueryResponse : PaginatedResultDto<FeedbackDto>
	{
		public GetListFeedbackQueryResponse(List<FeedbackDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
