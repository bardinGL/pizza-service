using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class OrderInTableConfigration : IEntityTypeConfiguration<OrderInTable>
    {
        public void Configure(EntityTypeBuilder<OrderInTable> builder)
        {
            builder.ToTable(TableNames.OrderInTable);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .HasMaxLength(50);

            builder.HasOne(x => x.Table)
                .WithMany(x => x.OrdersInTable)
                .HasForeignKey(x => x.TableId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.OrderInTable)
                .HasForeignKey(x => x.OrderInTableId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
