using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffScheduleService : DomainService, IStaffScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffScheduleRepository _staffScheduleRepository;

        public StaffScheduleService(IUnitOfWork unitOfWork, IStaffScheduleRepository staffScheduleRepository)
        {
            _unitOfWork = unitOfWork;
            _staffScheduleRepository = staffScheduleRepository;
        }

        public async Task<Guid> CreateAsync(DateTimeOffset schedualDate, TimeSpan shiftStart, TimeSpan shiftEnd, ConfigEnum status, Guid staffId, Guid zoneId)
        {
            var entity = new StaffSchedule(Guid.NewGuid(), schedualDate, shiftStart, shiftEnd, status, staffId, zoneId);
            _staffScheduleRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffScheduleRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _staffScheduleRepository.HardDelete(entity);
                }
                else
                {
                    _staffScheduleRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _staffScheduleRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _staffScheduleRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, DateTimeOffset schedualDate, TimeSpan shiftStart, TimeSpan shiftEnd, ConfigEnum status, Guid staffId, Guid zoneId)
        {
            var entity = await _staffScheduleRepository.GetSingleByIdAsync(id);
            entity.UpdateStaffSchedule(schedualDate, shiftStart, shiftEnd, status, staffId, zoneId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
