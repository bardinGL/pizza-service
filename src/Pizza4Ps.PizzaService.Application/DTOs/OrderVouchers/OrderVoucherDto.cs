using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers
{
	public class OrderVoucherDto
	{
        public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public Guid VoucherId { get; set; }

		public virtual Order Order { get; set; }
		public virtual Voucher Voucher { get; set; }
	}
}
