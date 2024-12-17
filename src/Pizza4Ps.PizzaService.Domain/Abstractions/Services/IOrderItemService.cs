namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOrderItemService
	{
		Task<Guid> CreateAsync(string name, int quantity, decimal price, Guid orderId, Guid productId);
		Task<Guid> UpdateAsync(Guid id, string name, int quantity, decimal price, Guid orderId, Guid productId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
