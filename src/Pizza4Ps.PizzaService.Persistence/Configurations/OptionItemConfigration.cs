using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class OptionItemConfigration : IEntityTypeConfiguration<OptionItem>
    {
        public void Configure(EntityTypeBuilder<OptionItem> builder)
        {
            builder.ToTable(TableNames.OptionItem);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.AdditionalPrice)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(x => x.Option)
                .WithMany(x => x.OptionItems)
                .HasForeignKey(x => x.OptionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OptionItemOrderItems)
                .WithOne(x => x.OptionItem)
                .HasForeignKey(x => x.OptionItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
