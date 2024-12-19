using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Products
{
    public class GetListProductIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
		public Guid? CategoryId { get; set; }
	}
}
