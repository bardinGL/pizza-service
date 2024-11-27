using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class OptionItem : EntityAuditBase<Guid>
	{
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid OptionId { get; set; }
		public virtual Option Option { get; set; }
		private OptionItem() { }
		public OptionItem(Guid id, decimal additionalPrice, Guid optionId)
		{
			Id = id;
			AdditionalPrice = additionalPrice;
			OptionId = optionId;

		}
	}
}
