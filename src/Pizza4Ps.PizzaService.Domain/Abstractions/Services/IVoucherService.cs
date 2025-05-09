﻿using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IVoucherService : IDomainService
    {
		Task<Guid> CreateAsync(string code, DiscountTypeEnum discountType, DateTime expiryDate, Guid voucherTypeId);
		Task<Guid> UpdateAsync(Guid id, string code, DiscountTypeEnum discountType, DateTime expiryDate, Guid voucherTypeId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
        Task<bool> UserVoucherAsync(Guid orderId, string code);
    }
}
