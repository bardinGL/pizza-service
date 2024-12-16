using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.RestoreOrder
{
	public class RestoreOrderCommandHandler : IRequestHandler<RestoreOrderCommand>
	{
		private readonly IOrderService _orderService;

		public RestoreOrderCommandHandler(IOrderService orderService)
		{
			_orderService = orderService;
		}

		public async Task Handle(RestoreOrderCommand request, CancellationToken cancellationToken)
		{
			await _orderService.RestoreAsync(request.Ids);
		}
	}
}
