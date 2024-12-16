using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedbackIgnoreQueryFilter
{
	public class GetListFeedbackIgnoreQueryFilterQueryResponse : PaginatedResultDto<FeedbackDto>
	{
		public GetListFeedbackIgnoreQueryFilterQueryResponse(List<FeedbackDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
