using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.CreateOptionItem
{
	public class CreateOptionItemCommand : IRequest<CreateOptionItemCommandResponse>
	{
		public CreateOptionItemDto CreateOptionItemDto { get; set; }
	}
}
