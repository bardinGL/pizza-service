using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems
{
	public class OptionItemOrderItemDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid OptionItemId { get; set; }
		public Guid OrderItemId { get; set; }

		public virtual OptionItem OptionItem { get; set; }
		public virtual OrderItem OrderItem { get; set; }
	}
}
