using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems
{
	public class GetListOptionItemOrderItemDto : PaginatedRequestDto
	{
		public string? Name { get; set; }
		public decimal? AdditionalPrice { get; set; }
		public Guid? OptionItemId { get; set; }
		public Guid? OrderItemId { get; set; }
	}
}
