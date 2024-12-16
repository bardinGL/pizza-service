using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CreateOrder
{
	public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
	{
		public CreateOrderDto CreateOrderDto { get; set; }
	}
}
