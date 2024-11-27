using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Option : EntityAuditBase<Guid>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<OptionItem> OptionItems { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }

        private Option() { }

		public Option(Guid id, string name, string description)
		{
			Id = id;
			Name = name;
			Description = description;
		}
	}
}
