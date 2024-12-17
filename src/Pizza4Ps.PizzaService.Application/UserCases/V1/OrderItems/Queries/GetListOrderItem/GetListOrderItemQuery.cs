using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem
{
	public class GetListOrderItemQuery : IRequest<GetListOrderItemQueryResponse>
	{
		public GetListOrderItemDto GetListOrderItemDto { get; set; }
	}
}
