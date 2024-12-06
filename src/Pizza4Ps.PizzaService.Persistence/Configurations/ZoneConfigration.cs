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

            builder.Property(x => x.Capacity)
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasMany(x => x.Tables)
                .WithOne(x => x.Zone)
                .HasForeignKey(x => x.ZoneId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.StaffZones)
                .WithOne(x => x.Zone)
                .HasForeignKey(x => x.ZoneId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.StaffSchedules)
                .WithOne(x => x.Zone)
                .HasForeignKey(x => x.ZoneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
