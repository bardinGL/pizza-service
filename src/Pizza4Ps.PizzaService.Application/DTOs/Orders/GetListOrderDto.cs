using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Orders
{
    public class GetListOrderDto : PaginatedRequestDto
    {
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string? Status { get; set; }
		public Guid? TableId { get; set; }
	}
}
