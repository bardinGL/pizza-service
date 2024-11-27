using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class OptionInOrderItem : EntityAuditBase<Guid>
	{

		public Guid OrderItemId { get; set; }
        public Guid OptiontemId { get; set; }

		public virtual OrderItem OrderItem { get; set; }
		public virtual OptionItem OptionItem { get; set; }

		private OptionInOrderItem() { }
		public OptionInOrderItem(Guid id, Guid orderitemId, Guid optionitemId)
		{
			Id = id;
			OrderItemId = orderitemId;
			OptiontemId = optionitemId;
		}
    }
}
