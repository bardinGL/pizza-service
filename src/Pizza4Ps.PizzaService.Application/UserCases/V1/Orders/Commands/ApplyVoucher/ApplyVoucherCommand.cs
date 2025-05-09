﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.ApplyVoucher
{
    public class ApplyVoucherCommand : IRequest
    {
        public Guid OrderId { get; set; }

        public string VoucherCode { get; set; }
    }
}
