using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTimeIgnoreQueryFilter
{
	public class GetListWorkingTimeIgnoreQueryFilterQuery : IRequest<GetListWorkingTimeIgnoreQueryFilterQueryResponse>
	{
		public GetListWorkingTimeIgnoreQueryFilterDto GetListWorkingTimeIgnoreQueryFilterDto { get; set; }
	}
}
