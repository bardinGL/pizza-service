using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class ProductOptionConfigration : IEntityTypeConfiguration<ProductOption>
	{
		public void Configure(EntityTypeBuilder<ProductOption> builder)
		{
			builder.ToTable(TableNames.ProductOption);
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Product)
				.WithMany()
				.HasForeignKey(x => x.ProductId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Option)
				.WithMany()
				.HasForeignKey(x => x.OptionId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
