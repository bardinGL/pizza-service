using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItemIgnoreQueryFilter
{
	public class GetListOrderItemIgnoreQueryFilterQueryResponse : PaginatedResultDto<OrderItemDto>
	{
		public GetListOrderItemIgnoreQueryFilterQueryResponse(List<OrderItemDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
