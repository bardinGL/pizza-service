using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class OptionItem : EntityAuditBase<Guid>
	{
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid OptionId { get; set; }

		public virtual Option Option { get; set; }

		public OptionItem()
		{
		}

		public OptionItem(Guid id, string name, decimal additionalPrice, Guid optionId)
		{
			Id = id;
			Name = name;
			AdditionalPrice = additionalPrice;
			OptionId = optionId;
		}

		public void UpdateOptionItem(string name, decimal additionalPrice, Guid optionId)
		{
			Name = name;
			AdditionalPrice = additionalPrice;
			OptionId = optionId;
		}
	}
}