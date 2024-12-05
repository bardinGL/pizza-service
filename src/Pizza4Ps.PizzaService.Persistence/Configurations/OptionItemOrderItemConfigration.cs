using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class OptionItemOrderItemConfigration : IEntityTypeConfiguration<OptionItemOrderItem>
    {
        public void Configure(EntityTypeBuilder<OptionItemOrderItem> builder)
        {
            builder.ToTable(TableNames.OptionItemOrderItem);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.AdditionalPrice)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.HasOne(x => x.OptionItem)
                .WithMany(x => x.OptionItemOrderItems)
                .HasForeignKey(x => x.OptionItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.OrderItem)
                .WithMany(x => x.OptionItemOrderItems)
                .HasForeignKey(x => x.OrderItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
