using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
	public class WorkingTimeRepository : RepositoryBase<WorkingTime, Guid>, IWorkingTimeRepository
	{
		public WorkingTimeRepository(ApplicationDBContext dBContext) : base(dBContext)
		{
		}
	}
}
