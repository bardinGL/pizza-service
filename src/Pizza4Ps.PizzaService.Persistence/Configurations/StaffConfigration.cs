using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class StaffConfigration : IEntityTypeConfiguration<Staff>
	{
		public void Configure(EntityTypeBuilder<Staff> builder)
		{
			builder.ToTable(TableNames.Staff);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Code)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.Phone)
				.HasMaxLength(15);

			builder.Property(x => x.Email)
				.HasMaxLength(100);

			builder.Property(x => x.StaffType)
				.IsRequired();

			builder.Property(x => x.Status)
				.IsRequired();
		}
	}
}
