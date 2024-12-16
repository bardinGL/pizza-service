using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class TableService : DomainService, ITableService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITableRepository _tableRepository;

        public TableService(IUnitOfWork unitOfWork, ITableRepository tableRepository)
        {
            _unitOfWork = unitOfWork;
            _tableRepository = tableRepository;
        }

        public async Task<Guid> CreateAsync(int tableNumber, int capacity, TableTypeEnum status, Guid zoneId)
        {
            var entity = new Table(Guid.NewGuid(), tableNumber, capacity, status, zoneId);
            _tableRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _tableRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _tableRepository.HardDelete(entity);
                }
                else
                {
                    _tableRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _tableRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _tableRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, int tableNumber, int capacity, TableTypeEnum status, Guid zoneId)
        {
            var entity = await _tableRepository.GetSingleByIdAsync(id);
            entity.UpdateTable(id, tableNumber, capacity, status, zoneId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
