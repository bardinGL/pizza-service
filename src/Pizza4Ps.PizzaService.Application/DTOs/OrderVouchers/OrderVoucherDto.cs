using Pizza4Ps.PizzaService.Application.DTOs.Orders;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;

namespace Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers
{
	public class OrderVoucherDto
	{
        public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public Guid VoucherId { get; set; }

		public virtual OrderDto Order { get; set; }
		public virtual VoucherDto Voucher { get; set; }
	}
}
