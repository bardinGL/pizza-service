using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Categories
{
	public class GetListCategoryIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
