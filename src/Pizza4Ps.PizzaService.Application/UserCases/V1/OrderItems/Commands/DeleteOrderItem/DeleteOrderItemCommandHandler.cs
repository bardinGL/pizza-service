using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.DeleteOrderItem
{
	public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
	{
		private readonly IOrderItemService _orderitemService;

		public DeleteOrderItemCommandHandler(IOrderItemService orderitemservice)
		{
			_orderitemService = orderitemservice;
		}

		public async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
		{
			await _orderitemService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
