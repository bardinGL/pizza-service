using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter
{
	public class GetListOptionItemOrderItemIgnoreQueryFilterQueryResponse : PaginatedResultDto<OptionItemOrderItemDto>
	{
		public GetListOptionItemOrderItemIgnoreQueryFilterQueryResponse(List<OptionItemOrderItemDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
