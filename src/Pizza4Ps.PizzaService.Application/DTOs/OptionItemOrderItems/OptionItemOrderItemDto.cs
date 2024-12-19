using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems
{
	public class OptionItemOrderItemDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid OptionItemId { get; set; }
		public Guid OrderItemId { get; set; }

		public virtual OptionItemDto OptionItem { get; set; }
		public virtual OrderItemDto OrderItem { get; set; }
	}
}
