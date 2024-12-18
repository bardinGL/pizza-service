using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTimeIgnoreQueryFilter
{
	public class GetListWorkingTimeIgnoreQueryFilterQueryResponse : PaginatedResultDto<WorkingTimeDto>
	{
		public GetListWorkingTimeIgnoreQueryFilterQueryResponse(List<WorkingTimeDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
