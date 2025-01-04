using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffScheduleService : IDomainService
    {
        Task<Guid> CreateAsync(DateTimeOffset schedualDate, TimeSpan shiftStart, TimeSpan shiftEnd, ConfigEnum status, Guid staffId, Guid zoneId);
        Task<Guid> UpdateAsync(Guid id, DateTimeOffset schedualDate, TimeSpan shiftStart, TimeSpan shiftEnd, ConfigEnum status, Guid staffId, Guid zoneId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}