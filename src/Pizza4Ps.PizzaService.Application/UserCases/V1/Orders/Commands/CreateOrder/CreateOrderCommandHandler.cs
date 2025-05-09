﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderService.CreateAsync(
                request.TableId, Domain.Enums.OrderTypeEnum.Order);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
