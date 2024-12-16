using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Options
{
    public class GetListOptionDto : PaginatedRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
