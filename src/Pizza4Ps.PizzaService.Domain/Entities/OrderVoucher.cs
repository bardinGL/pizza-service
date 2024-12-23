using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class OrderVoucher : EntityAuditBase<Guid>
	{
		public Guid OrderId { get; set; }
		public Guid VoucherId { get; set; }

		public virtual Order Order { get; set; }
		public virtual Voucher Voucher { get; set; }

		public OrderVoucher()
		{
		}

		public OrderVoucher(Guid id, Guid orderId, Guid voucherId)
		{
			Id = id;
			OrderId = orderId;
			VoucherId = voucherId;
		}

		public void UpdateOrderVoucher(Guid orderId, Guid voucherId)
		{
			OrderId = orderId;
			VoucherId = voucherId;
		}
	}
}
