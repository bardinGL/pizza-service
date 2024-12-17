using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.CreateOptionItemOrderItem
{
	public class CreateOptionItemOrderItemCommand : IRequest<CreateOptionItemOrderItemCommandResponse>
	{
		public CreateOptionItemOrderItemDto CreateOptionItemOrderItemDto { get; set; }
	}
}
