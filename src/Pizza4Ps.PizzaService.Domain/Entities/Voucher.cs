﻿using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Voucher : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual ICollection<OrderVoucher> OrderVouchers { get; set; }

        public Voucher()
        {
        }

        public Voucher(string code, DiscountTypeEnum discountType, DateTime? expiryDate)
        {
            Code = code;
            DiscountType = discountType;
            ExpiryDate = expiryDate;
        }
    }
}
