using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem
{
	public class GetListOrderItemQueryResponse : PaginatedResultDto<OrderItemDto>
	{
		public GetListOrderItemQueryResponse(List<OrderItemDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
