using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.OrderItems
{
	public class GetListOrderItemDto : PaginatedRequestDto
	{
		public string? Name { get; set; }
		public int? Quantity { get; set; }
		public decimal? Price { get; set; }
	}
}
