﻿using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
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
        private readonly IStaffZoneRepository _StaffZoneRepository;

        public StaffZoneService(IUnitOfWork unitOfWork, IStaffZoneRepository StaffZoneRepository)
        {
            _unitOfWork = unitOfWork;
            _StaffZoneRepository = StaffZoneRepository;
        }

        public async Task<Guid> CreateAsync(DateOnly workDate, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            var entity = new StaffZone(Guid.NewGuid(), workDate, shiftStart, shiftEnd, note, staffId, zoneId);
            _StaffZoneRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _StaffZoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _StaffZoneRepository.HardDelete(entity);
                }
                else
                {
                    _StaffZoneRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _StaffZoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _StaffZoneRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, DateOnly workDate, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            var entity = await _StaffZoneRepository.GetSingleByIdAsync(id);
            entity.UpdateStaffZone(workDate, shiftStart, shiftEnd, note, staffId, zoneId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
