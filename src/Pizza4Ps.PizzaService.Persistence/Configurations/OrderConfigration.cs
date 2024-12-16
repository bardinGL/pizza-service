using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable(TableNames.Order);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.StartTime)
				.IsRequired();

			builder.Property(x => x.EndTime)
				.IsRequired();

			builder.Property(x => x.Status)
				.HasMaxLength(50)
				.IsRequired(false);

			builder.HasOne(x => x.Table)
				.WithMany()
				.HasForeignKey(x => x.TableId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
