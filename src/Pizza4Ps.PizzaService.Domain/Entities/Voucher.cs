using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Voucher : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Voucher()
        {
        }

        public Voucher(Guid id, string code, DiscountTypeEnum discountType, DateTime expiryDate)
        {
            Id = id;
            Code = code;
            DiscountType = discountType;
            ExpiryDate = expiryDate;
        }

        public void UpdateVoucher(string code, DiscountTypeEnum discountType, DateTime expiryDate)
        {
            Code = code;
            DiscountType = discountType;
            ExpiryDate = expiryDate;
        }
    }
}
