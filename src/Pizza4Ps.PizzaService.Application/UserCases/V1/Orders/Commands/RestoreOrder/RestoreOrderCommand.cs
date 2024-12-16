using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.RestoreOrder
{
	public class RestoreOrderCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
