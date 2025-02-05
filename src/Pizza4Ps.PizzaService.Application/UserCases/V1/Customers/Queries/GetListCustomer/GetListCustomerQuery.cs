﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQuery : PaginatedQuery<PaginatedResultDto<CustomerDto>>
    {
        public string? FullName { get; set; }
        public string? Phone { get; set; }

    }
}
