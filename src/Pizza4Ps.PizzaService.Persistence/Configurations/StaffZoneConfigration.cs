using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class StaffZoneConfigration : IEntityTypeConfiguration<StaffZone>
	{
		public void Configure(EntityTypeBuilder<StaffZone> builder)
		{
			builder.ToTable(TableNames.StaffZone);

			builder.HasKey(x => x.Id);

			builder.Property(x => x.StaffId)
				.IsRequired();

			builder.HasOne(x => x.Staff)
				.WithMany()
				.HasForeignKey(x => x.StaffId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Zone)
				.WithMany()
				.HasForeignKey(x => x.ZoneId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
