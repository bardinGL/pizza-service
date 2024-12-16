using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedbackIgnoreQueryFilter
{
	public class GetListFeedbackIgnoreQueryFilterQuery : IRequest<GetListFeedbackIgnoreQueryFilterQueryResponse>
	{
		public GetListFeedbackIgnoreQueryFilterDto GetListFeedbackIgnoreQueryFilterDto { get; set; }
	}
}
