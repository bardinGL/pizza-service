﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
