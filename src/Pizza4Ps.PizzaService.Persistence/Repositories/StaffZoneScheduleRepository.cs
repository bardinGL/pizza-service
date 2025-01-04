using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class StaffZoneScheduleRepository : RepositoryBase<StaffZoneSchedule, Guid>, IStaffZoneScheduleRepository
    {
        public StaffZoneScheduleRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}