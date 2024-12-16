using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Products
{
	public class GetListProductDto : PaginatedRequestDto
	{
		public string? Name { get; set; }
		public decimal? Price { get; set; }
		public string? Description { get; set; }
	}
}
