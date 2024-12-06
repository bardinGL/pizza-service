using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ScheduleConfigConfigration : IEntityTypeConfiguration<ScheduleConfig>
    {
        public void Configure(EntityTypeBuilder<ScheduleConfig> builder)
        {
            throw new NotImplementedException();
        }
    }
}
