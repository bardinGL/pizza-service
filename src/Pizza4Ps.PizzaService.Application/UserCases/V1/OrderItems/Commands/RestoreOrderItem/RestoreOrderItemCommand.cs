using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.RestoreOrderItem
{
	public class RestoreOrderItemCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
