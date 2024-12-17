using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.RestoreOptionItem
{
	public class RestoreOptionItemCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
