using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class TableConfigration : IEntityTypeConfiguration<Table>
	{
		public void Configure(EntityTypeBuilder<Table> builder)
		{
			builder.ToTable(TableNames.Table);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.TableNumber)
				.IsRequired();

			builder.Property(x => x.Capacity)
				.IsRequired();

			builder.Property(x => x.Status)
				.HasConversion<int>()
				.IsRequired();

			builder.HasOne(x => x.Zone)
				.WithMany()
				.HasForeignKey(x => x.ZoneId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
