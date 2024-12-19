using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IWorkingTimeService : IDomainService
	{
		Task<Guid> CreateAsync(int dayOfWeek, string shiftCode, string name, TimeSpan startTime, TimeSpan endTime);
		Task<Guid> UpdateAsync(Guid id, int dayOfWeek, string shiftCode, string name, TimeSpan startTime, TimeSpan endTime);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
