﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.CreateOptionItemOrderItem
{
    public class CreateOptionItemOrderItemCommand : IRequest<ResultDto<Guid>>
	{
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OptionItemId { get; set; }
        public Guid OrderItemId { get; set; }
    }
}
