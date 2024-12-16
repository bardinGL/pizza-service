using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs.Payments
{
	public class UpdatePaymentDto
	{
		public decimal Amount { get; set; } = decimal.Zero;
		public PaymentMethodEnum PaymentMethod { get; set; } = PaymentMethodEnum.Cash;
		public string Status { get; set; }
		public Guid OrderId { get; set; }
	}
}
