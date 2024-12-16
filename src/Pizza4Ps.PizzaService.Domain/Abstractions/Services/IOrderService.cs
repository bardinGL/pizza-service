using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IOrderService : IDomainService
    {
		Task<Guid> CreateAsync(DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid TableId);
		Task<Guid> UpdateAsync(Guid id, DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid TableId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
