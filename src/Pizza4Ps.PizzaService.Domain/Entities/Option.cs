using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Option : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Option()
        {
        }

        public Option(Guid id,string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

		public void UpdateOption(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}