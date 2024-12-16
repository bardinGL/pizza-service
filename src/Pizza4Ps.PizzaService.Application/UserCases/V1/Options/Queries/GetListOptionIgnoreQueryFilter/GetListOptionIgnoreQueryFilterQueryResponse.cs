using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Options;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionIgnoreQueryFilter
{
	public class GetListOptionIgnoreQueryFilterQueryResponse : PaginatedResultDto<OptionDto>
	{
		public GetListOptionIgnoreQueryFilterQueryResponse(List<OptionDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
