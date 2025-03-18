﻿using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class VoucherDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid VoucherTypeId { get; set;}
    }
}
