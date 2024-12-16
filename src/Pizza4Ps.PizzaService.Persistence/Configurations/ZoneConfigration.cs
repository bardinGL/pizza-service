using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class ZoneConfigration : IEntityTypeConfiguration<Zone>
	{
		public void Configure(EntityTypeBuilder<Zone> builder)
		{
			builder.ToTable(TableNames.Zone);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.Capacity);

			builder.Property(x => x.Description)
				.HasMaxLength(500)
				.IsRequired(false);

			builder.Property(x => x.Status)
				.IsRequired();
		}
	}
}
