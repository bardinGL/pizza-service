﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPaymentIgnoreQueryFilter
{
    public class GetListPaymentIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<PaymentDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public decimal? Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public Guid? OrderId { get; set; }
    }
}
