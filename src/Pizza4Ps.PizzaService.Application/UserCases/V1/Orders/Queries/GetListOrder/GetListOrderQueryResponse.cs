using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrder
{
	public class GetListOrderQueryResponse : PaginatedResultDto<OrderDto>
	{
		public GetListOrderQueryResponse(List<OrderDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
