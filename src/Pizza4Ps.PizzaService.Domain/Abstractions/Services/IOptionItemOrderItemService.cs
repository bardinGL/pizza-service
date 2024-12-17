namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOptionItemOrderItemService
	{
		Task<Guid> CreateAsync(string name, decimal additionalPrice, Guid optionItemId, Guid orderItemId);
		Task<Guid> UpdateAsync(Guid id, string name, decimal additionalPrice, Guid optionItemId, Guid orderItemId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
