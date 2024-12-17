using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IProductOptionService : IDomainService
	{
		Task<Guid> CreateAsync(Guid productId, Guid optionId);
		Task<Guid> UpdateAsync(Guid id, Guid productId, Guid optionId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
