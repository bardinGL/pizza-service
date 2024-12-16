using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.DeleteOption
{
	public class DeleteOptionCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
