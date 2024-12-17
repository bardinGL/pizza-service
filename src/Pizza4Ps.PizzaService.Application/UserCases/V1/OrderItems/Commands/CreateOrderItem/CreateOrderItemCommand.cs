using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.CreateOrderItem
{
	public class CreateOrderItemCommand : IRequest<CreateOrderItemCommandResponse>
	{
		public CreateOrderItemDto CreateOrderItemDto { get; set; }
	}
}
