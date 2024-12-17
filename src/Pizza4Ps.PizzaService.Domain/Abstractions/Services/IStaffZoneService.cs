namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffZoneService
    {
        Task<Guid> CreateAsync(DateOnly workDate, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId);
        Task<Guid> UpdateAsync(Guid id, DateOnly workDate, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
    