using Pizza4Ps.PizzaService.Domain.Abstractions;
using System.Diagnostics;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Category()
        {
        }

        public Category(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public void UpdateCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
