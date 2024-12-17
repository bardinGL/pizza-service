using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItem
{
	public class UpdateOptionItemCommand : IRequest<UpdateOptionItemCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateOptionItemDto UpdateOptionItemDto { get; set; }
	}
}
