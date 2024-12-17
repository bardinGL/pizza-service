using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.DeleteOrderItem
{
	public class DeleteOrderItemCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
