using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
	{
		private readonly IOrderService _orderService;

		public UpdateOrderCommandHandler(IOrderService orderService)
		{
			_orderService = orderService;
		}

		public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderService.UpdateAsync(
				request.Id,
				request.UpdateOrderDto.StartTime,
				request.UpdateOrderDto.EndTime,
				request.UpdateOrderDto.Status,
				request.UpdateOrderDto.TableId);
			return new UpdateOrderCommandResponse
			{
				Id = result
			};
		}
	}
}
