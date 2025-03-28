using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IVoucherTypeService : IDomainService
    {
		Task<Guid> CreateAsync(string name, string description, int totalQuantity, DiscountTypeEnum discountType, decimal amount, DateTime expiryDate);
    }
}
