using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItems
{
	public class GetListOptionItemIgnoreQueryFilterDto : PaginatedRequestDto
	{
        public bool IsDeleted { get; set; } = false;
		public string? Name { get; set; }
		public decimal? AdditionalPrice { get; set; }
		public Guid? OptionId { get; set; }
	}
}
