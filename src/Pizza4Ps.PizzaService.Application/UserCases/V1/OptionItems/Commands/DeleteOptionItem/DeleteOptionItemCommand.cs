using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.DeleteOptionItem
{
	public class DeleteOptionItemCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
