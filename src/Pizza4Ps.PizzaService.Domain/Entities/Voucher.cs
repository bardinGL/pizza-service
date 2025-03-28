using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Voucher : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid VoucherTypeId { get; set; }

        public virtual VoucherType VoucherType { get; set; }

        public Voucher()
        {
        }

        public Voucher(Guid id, string code, DiscountTypeEnum discountType, decimal amount, DateTime expiryDate, Guid voucherTypeId)
        {
            Id = id;
            Code = code;
            DiscountType = discountType;
            Amount = amount;
            ExpiryDate = expiryDate;
            VoucherTypeId = voucherTypeId;
        }

        public void UpdateVoucher(string code, DiscountTypeEnum discountType, decimal amount, DateTime expiryDate, Guid voucherTypeId)
        {
            Code = code;
            DiscountType = discountType;
            Amount = amount;
            ExpiryDate = expiryDate;
            VoucherTypeId = voucherTypeId;
        }
    }
}
