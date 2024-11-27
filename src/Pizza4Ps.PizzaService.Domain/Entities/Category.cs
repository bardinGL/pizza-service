using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        private Category() { }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
