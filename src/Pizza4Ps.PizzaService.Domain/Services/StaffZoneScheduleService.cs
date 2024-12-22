using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffZoneScheduleService : DomainService, IStaffZoneScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffZoneScheduleRepository _StaffZoneScheduleRepository;

        public StaffZoneScheduleService(IUnitOfWork unitOfWork, IStaffZoneScheduleRepository StaffZoneScheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _StaffZoneScheduleRepository = StaffZoneScheduleRepository;
        }

        public async Task<Guid> CreateAsync(DateOnly dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId, Guid workingtimeId)
        {
            var entity = new StaffZoneSchedule(Guid.NewGuid(), dayofWeek, shiftStart, shiftEnd, note, staffId, zoneId, workingtimeId);
            _StaffZoneScheduleRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _StaffZoneScheduleRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _StaffZoneScheduleRepository.HardDelete(entity);
                }
                else
                {
                    _StaffZoneScheduleRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _StaffZoneScheduleRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _StaffZoneScheduleRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, DateOnly dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId, Guid workingtimeId)
        {
            var entity = await _StaffZoneScheduleRepository.GetSingleByIdAsync(id);
            entity.UpdateStaffZoneSchedule(dayofWeek, shiftStart, shiftEnd, note, staffId, zoneId, workingtimeId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
