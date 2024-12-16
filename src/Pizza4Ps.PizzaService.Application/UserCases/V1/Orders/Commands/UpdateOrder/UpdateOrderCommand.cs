using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommand : IRequest<UpdateOrderCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateOrderDto UpdateOrderDto { get; set; }
	}
}
