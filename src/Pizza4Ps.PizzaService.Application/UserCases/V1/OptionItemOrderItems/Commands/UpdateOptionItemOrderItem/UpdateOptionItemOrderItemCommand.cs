using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.UpdateOptionItemOrderItem
{
	public class UpdateOptionItemOrderItemCommand : IRequest<UpdateOptionItemOrderItemCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateOptionItemOrderItemDto UpdateOptionItemOrderItemDto { get; set; }
	}
}
