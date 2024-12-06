using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class TableBookingConfigration : IEntityTypeConfiguration<TableBooking>
    {
        public void Configure(EntityTypeBuilder<TableBooking> builder)
        {
            builder.ToTable(TableNames.TableBooking);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OnholdTime)
                .IsRequired();

            builder.HasOne(x => x.Table)
                .WithMany(x => x.TableBookings)
                .HasForeignKey(x => x.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Booking)
                .WithMany(x => x.TableBookings)
                .HasForeignKey(x => x.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
