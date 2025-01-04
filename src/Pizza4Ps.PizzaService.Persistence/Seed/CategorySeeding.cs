using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Seed
{
    public class CategorySeeding : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category(Guid.Parse("AD8A1D13-A895-4A94-D20C-08DCF26F96D8"), "Đồ ăn", ""),
                new Category(Guid.Parse("8BF80BC9-2302-4E36-B4CA-146CE7D34543"), "Đồ uống", "")
                );
        }
    }
}
