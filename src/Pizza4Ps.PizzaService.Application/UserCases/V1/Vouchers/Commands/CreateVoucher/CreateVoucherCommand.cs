﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.CreateVoucher
{
    public class CreateVoucherCommand : IRequest<ResultDto<Guid>>
	{
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
