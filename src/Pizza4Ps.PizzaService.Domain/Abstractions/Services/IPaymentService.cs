using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IPaymentService
	{
		Task<Guid> CreateAsync(decimal amount, PaymentMethodEnum paymentMethod, string status, Guid orderId);
		Task<Guid> UpdateAsync(Guid id, decimal amount, PaymentMethodEnum paymentMethod, string status, Guid orderId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
