using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class VoucherType : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int TotalQuantity { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }

        public VoucherType()
        {
        }

        public VoucherType(Guid id, string name, string description, int totalQuantity, DiscountTypeEnum discountType, decimal amount, DateTime expiryDate)
        {
            Id = id;
            Name = name;
            Description = description;
            TotalQuantity = ValidateTotalQuantity(totalQuantity);
            DiscountType = discountType;
            Amount = amount;
            ExpiryDate = expiryDate;
        }

        private int ValidateTotalQuantity(int totalQuantity)
        {
            if (totalQuantity <= 0)
            {
                throw new BusinessException(BussinessErrorConstants.VoucherTypeErrorConstant.TOTAL_QUANTITY_INVALID);
            }
            return totalQuantity;
        }
    }
}