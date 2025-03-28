using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class VoucherTypeService : DomainService, IVoucherTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVoucherTypeRepository _voucherTypeRepository;

        public VoucherTypeService(IUnitOfWork unitOfWork, IVoucherTypeRepository voucherTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _voucherTypeRepository = voucherTypeRepository;
        }

        public async Task<Guid> CreateAsync(string name, string description, int totalQuantity, DiscountTypeEnum discountType, decimal amount, DateTime expiryDate)
        {
            var entity = new VoucherType(Guid.NewGuid(), name, description, totalQuantity, discountType, amount, expiryDate);
            _voucherTypeRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
