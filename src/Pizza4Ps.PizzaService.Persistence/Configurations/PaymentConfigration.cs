using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class PaymentConfigration : IEntityTypeConfiguration<Payment>
	{
		public void Configure(EntityTypeBuilder<Payment> builder)
		{
			builder.ToTable(TableNames.Payment);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Amount)
				.IsRequired()
				.HasColumnType("decimal(18, 2)");

			builder.Property(x => x.PaymentMethod)
				.IsRequired();

			builder.Property(x => x.Status)
				.HasMaxLength(50)
				.IsRequired(false);

			builder.HasOne(x => x.Order)
				.WithMany()
				.HasForeignKey(x => x.OrderId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
