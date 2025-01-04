using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Seed
{
    public class ProductSeeding : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("AD8A1D13-A895-4A94-D20C-08DCF26F96D8"),
                    CategoryId = Guid.Parse("AD8A1D13-A895-4A94-D20C-08DCF26F96D8"),
                    Name = "Pizza hut",
                    Price = 1000,
                    Description = "Pizza"
                },
                new Product
                {
                    Id = Guid.Parse("8BF80BC9-2302-4E36-B4CA-146CE7D34543"),
                    CategoryId = Guid.Parse("8BF80BC9-2302-4E36-B4CA-146CE7D34543"),
                    Name = "Pizza In",
                    Price = 1200,
                    Description = "Pizza"
                }
            );
        }
    }
}
