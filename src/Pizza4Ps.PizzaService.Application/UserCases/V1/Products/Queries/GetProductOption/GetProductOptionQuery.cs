﻿using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductOption
{
    public class GetProductOptionQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
