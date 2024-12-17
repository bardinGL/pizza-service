using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItemIgnoreQueryFilter
{
	public class GetListOptionItemIgnoreQueryFilterQueryResponse : PaginatedResultDto<OptionItemDto>
	{
		public GetListOptionItemIgnoreQueryFilterQueryResponse(List<OptionItemDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
