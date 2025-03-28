using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.UpdateVoucher
{
    public class UpdateVoucherCommand : IRequest
	{
		public Guid? Id { get; set; }
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid VoucherTypeId { get; set; }
    }
}
