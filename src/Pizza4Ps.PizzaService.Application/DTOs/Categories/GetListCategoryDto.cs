using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Categories
{
    public class GetListCategoryDto : PaginatedRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
