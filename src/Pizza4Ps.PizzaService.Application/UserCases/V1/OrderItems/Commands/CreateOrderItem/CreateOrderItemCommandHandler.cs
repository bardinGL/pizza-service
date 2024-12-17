using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.CreateOrderItem
{
	public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, CreateOrderItemCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemService _orderitemService;

		public CreateOrderItemCommandHandler(IMapper mapper, IOrderItemService orderitemService)
		{
			_mapper = mapper;
			_orderitemService = orderitemService;
		}

		public async Task<CreateOrderItemCommandResponse> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderitemService.CreateAsync(
				request.CreateOrderItemDto.Name,
				request.CreateOrderItemDto.Quantity,
				request.CreateOrderItemDto.Price,
				request.CreateOrderItemDto.OrderId,
				request.CreateOrderItemDto.ProductId);
			return new CreateOrderItemCommandResponse
			{
				Id = result
			};
		}
	}
}
