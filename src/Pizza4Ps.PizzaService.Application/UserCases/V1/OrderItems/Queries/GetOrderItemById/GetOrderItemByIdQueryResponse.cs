using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemById
{
	public class GetOrderItemByIdQueryResponse
	{
		public OrderItemDto OrderItem { get; set; }
	}
}
