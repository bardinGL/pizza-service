using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ZoneService : DomainService, IZoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IZoneRepository _zoneRepository;

        public ZoneService(IUnitOfWork unitOfWork, IZoneRepository zoneRepository)
        {
            _unitOfWork = unitOfWork;
            _zoneRepository = zoneRepository;
        }

        public async Task<Guid> CreateAsync(string name, int capacity, string description, ZoneTypeEnum status)
        {
            var entity = new Zone(Guid.NewGuid(), name, capacity, description, status);
            _zoneRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _zoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _zoneRepository.HardDelete(entity);
                }
                else
                {
                    _zoneRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _zoneRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _zoneRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string name, int capacity, string description, ZoneTypeEnum status)
        {
            var entity = await _zoneRepository.GetSingleByIdAsync(id);
            entity.UpdateZone(name, capacity, description, status);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
