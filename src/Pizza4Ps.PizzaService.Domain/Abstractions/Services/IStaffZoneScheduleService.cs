﻿using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IStaffZoneScheduleService : IDomainService
    {
        Task<Guid> CreateAsync(DateOnly date, Guid staffId, Guid zoneId, Guid workingSlotIdId);
        Task AutoAssignZoneAsync(DateOnly workingDate);
        //Task<Guid> UpdateAsync(Guid id, staffId, Guid zoneId, Guid workingSlotIdId );
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}

