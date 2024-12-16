using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Options;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOption
{
	public class UpdateOptionCommand : IRequest<UpdateOptionCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateOptionDto UpdateOptionDto { get; set; }
	}
}
