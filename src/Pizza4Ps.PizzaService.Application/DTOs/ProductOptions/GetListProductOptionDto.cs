using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.ProductOptions
{
	public class GetListProductOptionDto : PaginatedRequestDto
	{
		public Guid? ProductId { get; set; }
		public Guid? OptionId { get; set; }
	}
}
