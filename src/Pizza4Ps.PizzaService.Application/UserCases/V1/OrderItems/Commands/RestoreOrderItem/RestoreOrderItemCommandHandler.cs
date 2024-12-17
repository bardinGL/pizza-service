using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.RestoreOrderItem
{
	public class RestoreOrderItemCommandHandler : IRequestHandler<RestoreOrderItemCommand>
	{
		private readonly IOrderItemService _orderitemService;

		public RestoreOrderItemCommandHandler(IOrderItemService orderitemService)
		{
			_orderitemService = orderitemService;
		}

		public async Task Handle(RestoreOrderItemCommand request, CancellationToken cancellationToken)
		{
			await _orderitemService.RestoreAsync(request.Ids);
		}
	}
}
