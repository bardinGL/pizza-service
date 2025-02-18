﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
