namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffZoneService
    {
        Task<Guid> CreateAsync(TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId);
        Task<Guid> UpdateAsync(Guid id, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
    