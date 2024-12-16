using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
	public interface IFeedbackService : IDomainService
	{
		Task<Guid> CreateAsync(int rating, string comments, Guid orderId);
		Task<Guid> UpdateAsync(Guid id, int rating, string comments, Guid orderId);
		Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false);
		Task RestoreAsync(List<Guid> ids);
	}
}
