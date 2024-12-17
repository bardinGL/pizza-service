using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
	public class UpdateOrderItemCommand : IRequest<UpdateOrderItemCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateOrderItemDto UpdateOrderItemDto { get; set; }
	}
}
