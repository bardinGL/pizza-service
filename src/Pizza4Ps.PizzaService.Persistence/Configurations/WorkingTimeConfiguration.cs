using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class WorkingTimeConfiguration : IEntityTypeConfiguration<WorkingTime>
	{
		public void Configure(EntityTypeBuilder<WorkingTime> builder)
		{
			builder.ToTable(TableNames.WorkingTime);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.DayOfWeek)
				.IsRequired();

			builder.Property(x => x.ShiftCode)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.StartTime)
				.IsRequired();

			builder.Property(x => x.EndTime)
				.IsRequired();
		}
	}
}
