using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable(TableNames.OrderItem);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.Quantity)
				.IsRequired();

			builder.Property(x => x.Price)
				.IsRequired()
				.HasColumnType("decimal(18,2)");

			builder.HasOne(x => x.Order)
				.WithMany()
				.HasForeignKey(x => x.OrderId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Product)
				.WithMany()
				.HasForeignKey(x => x.ProductId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
