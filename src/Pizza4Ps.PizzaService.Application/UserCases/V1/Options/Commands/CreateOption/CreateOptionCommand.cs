using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Options;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.CreateOption
{
	public class CreateOptionCommand : IRequest<CreateOptionCommandResponse>
	{
		public CreateOptionDto CreateOptionDto { get; set; }
	}
}
