using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface ITableBookingService
	{
		Task<Guid> CreateAsync(DateTime onholdTime, Guid tableId, Guid bookingId);
		Task<Guid> UpdateAsync(Guid id, DateTime onholdTime, Guid tableId, Guid bookingId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
