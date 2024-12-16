using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class BookingConfigration : EntityBase<Booking>
	{
		public void Configure(EntityTypeBuilder<Booking> builder)
		{
			builder.ToTable(TableNames.Booking);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.BookingDate)
				.IsRequired();

			builder.Property(x => x.GuestCount)
				.IsRequired();

			builder.Property(x => x.Status)
				.IsRequired()
				.HasMaxLength(50);

			builder.HasOne(x => x.Customer)
				.WithMany()
				.HasForeignKey(x => x.CustomerId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
