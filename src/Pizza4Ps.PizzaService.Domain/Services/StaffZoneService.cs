using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class StaffZoneService : DomainService, IStaffZoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffZoneRepository _staffZoneRepository;

        public StaffZoneService(IUnitOfWork unitOfWork, IStaffZoneRepository staffZoneRepository)
        {
            _unitOfWork = unitOfWork;
            _staffZoneRepository = staffZoneRepository;
        }

        public async Task<Guid> CreateAsync(TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            var entity = new StaffZone(Guid.NewGuid(), shiftStart, shiftEnd, note, staffId, zoneId);
            _staffZoneRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffZoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _staffZoneRepository.HardDelete(entity);
                }
                else
                {
                    _staffZoneRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _staffZoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _staffZoneRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            var entity = await _staffZoneRepository.GetSingleByIdAsync(id);
            entity.UpdateStaffZone(shiftStart, shiftEnd, note, staffId, zoneId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
