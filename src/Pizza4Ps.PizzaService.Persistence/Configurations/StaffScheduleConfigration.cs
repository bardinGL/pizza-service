using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class StaffScheduleConfigration : IEntityTypeConfiguration<StaffSchedule>
    {
        public void Configure(EntityTypeBuilder<StaffSchedule> builder)
        {
            throw new NotImplementedException();
        }
    }
}
