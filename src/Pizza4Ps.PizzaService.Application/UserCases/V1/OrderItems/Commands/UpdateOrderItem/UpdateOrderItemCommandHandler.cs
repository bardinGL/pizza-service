using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
	public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, UpdateOrderItemCommandResponse>
	{
		private readonly IOrderItemService _orderitemService;

		public UpdateOrderItemCommandHandler(IOrderItemService orderitemService)
		{
			_orderitemService = orderitemService;
		}

		public async Task<UpdateOrderItemCommandResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderitemService.UpdateAsync(
				request.Id,
				request.UpdateOrderItemDto.Name,
				request.UpdateOrderItemDto.Quantity,
				request.UpdateOrderItemDto.Price,
				request.UpdateOrderItemDto.OrderId,
				request.UpdateOrderItemDto.ProductId);
			return new UpdateOrderItemCommandResponse
			{
				Id = result
			};
		}
	}
}
