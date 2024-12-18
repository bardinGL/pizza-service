using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTime
{
	public class GetListWorkingTimeQueryResponse : PaginatedResultDto<WorkingTimeDto>
	{
		public GetListWorkingTimeQueryResponse(List<WorkingTimeDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
