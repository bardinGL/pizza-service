namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOrderVoucherService
	{
		Task<Guid> CreateAsync(Guid orderId, Guid voucherId);
		Task<Guid> UpdateAsync(Guid id, Guid orderId, Guid voucherId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
