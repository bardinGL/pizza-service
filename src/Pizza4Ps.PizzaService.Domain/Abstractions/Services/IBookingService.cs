using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IBookingService : IDomainService
    {
        Task<Guid> CreateAsync(DateTime bookingDate, int guestCount, string status, Guid customerId);
        Task<Guid> UpdateAsync(Guid id, DateTime bookingDate, int guestCount, string status, Guid customerId);
        Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
        Task RestoreAsync(List<Guid> ids);
    }
}
