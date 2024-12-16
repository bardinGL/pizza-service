using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IStaffService : IDomainService
    {
		Task<Guid> CreateAsync(string code, string name, string phone, string email, StaffTypeEnum.StaffType staffType, StaffTypeEnum.StaffStatus status);
		Task<Guid> UpdateAsync(Guid id, string code, string name, string phone, string email, StaffTypeEnum.StaffType staffType, StaffTypeEnum.StaffStatus status);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
