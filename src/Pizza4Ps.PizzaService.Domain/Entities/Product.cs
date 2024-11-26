using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Product : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        private Product()
        {
            
        }
        public Product(Guid id, string name, decimal price, string description, Guid categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryId;
        }
        public void UpdateProduct(string name, decimal price, string description, Guid categoryId)
        {
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
