using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class VoucherService : DomainService, IVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVoucherRepository _voucherRepository;

        public VoucherService(IUnitOfWork unitOfWork, IVoucherRepository voucherRepository)
        {
            _unitOfWork = unitOfWork;
            _voucherRepository = voucherRepository;
        }

        public async Task<Guid> CreateAsync(string code, DiscountTypeEnum discountType, DateTime expiryDate)
        {
            var entity = new Voucher(Guid.NewGuid(), code, discountType, expiryDate);
            _voucherRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _voucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _voucherRepository.HardDelete(entity);
                }
                else
                {
                    _voucherRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _voucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _voucherRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Guid> UpdateAsync(Guid id, string code, DiscountTypeEnum discountType, DateTime expiryDate)
        {
            var entity = await _voucherRepository.GetSingleByIdAsync(id);
            entity.UpdateVoucher(code, discountType, expiryDate);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
