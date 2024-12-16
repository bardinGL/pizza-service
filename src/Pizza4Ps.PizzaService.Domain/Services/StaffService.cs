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
    public class StaffService : DomainService, IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffRepository _staffRepository;

        public StaffService(IUnitOfWork unitOfWork, IStaffRepository staffRepository)
        {
            _unitOfWork = unitOfWork;
            _staffRepository = staffRepository;
        }

        public async Task<Guid> CreateAsync(string code, string name, string phone, string email, StaffTypeEnum.StaffType staffType, StaffTypeEnum.StaffStatus status)
        {
            var entity = new Staff(Guid.NewGuid(), code, name, phone, email, staffType, status);
            _staffRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _staffRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _staffRepository.HardDelete(entity);
                }
                else
                {
                    _staffRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _staffRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _staffRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string code, string name, string phone, string email, StaffTypeEnum.StaffType staffType, StaffTypeEnum.StaffStatus status)
        {
            var entity = await _staffRepository.GetSingleByIdAsync(id);
            entity.UpdateStaff(code, name, phone, email, staffType, status);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
