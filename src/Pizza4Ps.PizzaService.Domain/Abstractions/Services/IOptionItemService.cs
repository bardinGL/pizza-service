using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOptionItemService : IDomainService
	{
		Task<Guid> CreateAsync(string name, decimal additionalPrice, Guid optionId);
		Task<Guid> UpdateAsync(Guid id, string name, decimal additionalPrice, Guid optionId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
