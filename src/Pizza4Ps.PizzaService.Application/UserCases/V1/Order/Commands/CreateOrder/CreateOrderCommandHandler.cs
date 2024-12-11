﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.CreateOrder
{
	public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;

		public CreateOrderCommandHandler(IMapper mapper, IOrderService orderService)
		{
			_mapper = mapper;
			_orderService = orderService;
		}

		public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderService.CreateAsync(request.StartTime, request.EndTime, request.Status, request.OrderInTableId);
			return new CreateOrderCommandResponse
			{
				Id = result
			};
		}
	}
}
