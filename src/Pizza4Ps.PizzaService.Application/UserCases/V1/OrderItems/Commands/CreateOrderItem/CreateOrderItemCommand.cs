﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public string? Note { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }

    }
}
