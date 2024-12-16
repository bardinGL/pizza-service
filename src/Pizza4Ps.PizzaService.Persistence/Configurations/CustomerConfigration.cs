using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class CustomerConfigration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable(TableNames.Customer);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.FullName)
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(x => x.Phone);
		}
	}
}
