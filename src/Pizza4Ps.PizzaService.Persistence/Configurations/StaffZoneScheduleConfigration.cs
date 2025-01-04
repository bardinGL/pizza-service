using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class StaffZoneScheduleConfigration : IEntityTypeConfiguration<StaffZoneSchedule>
    {
        public void Configure(EntityTypeBuilder<StaffZoneSchedule> builder)
        {
            builder.ToTable(TableNames.StaffZoneSchedule);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DayofWeek)
                .IsRequired();

            builder.Property(x => x.ShiftStart)
                .IsRequired();

            builder.Property(x => x.ShiftEnd)
                .IsRequired();

            builder.Property(x => x.Note)
                .HasMaxLength(500)
                .HasColumnName("Note");

            builder.Property(x => x.StaffId)
                .IsRequired();


            builder.Property(x => x.ZoneId)
                .IsRequired();

            builder.Property(x => x.WorkingTimeId)
                .IsRequired();

            builder.HasOne(x => x.Staff)
                .WithMany()
                .HasForeignKey(x => x.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Zone)
                .WithMany()
                .HasForeignKey(x => x.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WorkingTime)
                .WithMany()
                .HasForeignKey(x => x.WorkingTimeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
