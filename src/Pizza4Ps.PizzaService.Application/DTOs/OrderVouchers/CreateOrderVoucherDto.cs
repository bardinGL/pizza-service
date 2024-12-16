namespace Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers
{
	public class CreateOrderVoucherDto
	{
		public Guid OrderId { get; set; }
		public Guid VoucherId { get; set; }
	}
}
