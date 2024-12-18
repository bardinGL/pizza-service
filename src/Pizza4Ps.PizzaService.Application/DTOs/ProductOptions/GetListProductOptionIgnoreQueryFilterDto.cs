using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.ProductOptions
{
	public class GetListProductOptionIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public Guid? ProductId { get; set; }
		public Guid? OptionId { get; set; }
	}
}
