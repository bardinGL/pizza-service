using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.DeleteOrder
{
	public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
	{
		private readonly IOrderService _orderService;

		public DeleteOrderCommandHandler(IOrderService orderService)
		{
			_orderService = orderService;
		}

		public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
		{
			await _orderService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
