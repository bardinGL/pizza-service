using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItem
{
	public class GetListOptionItemOrderItemQueryResponse : PaginatedResultDto<OptionItemOrderItemDto>
	{
		public GetListOptionItemOrderItemQueryResponse(List<OptionItemOrderItemDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
