using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.TableBookings
{
	public class GetListTableBookingIgnoreQueryFilterDto : PaginatedRequestDto
	{
        public bool IsDeleted { get; set; } = false;
		public DateTime? OnholdTime { get; set; }
		public Guid? TableId { get; set; }
		public Guid? BookingId { get; set; }
	}
}
