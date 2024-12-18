using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.TableBookings
{
	public class GetListTableBookingDto : PaginatedRequestDto
	{
		public DateTime? OnholdTime { get; set; }
		public Guid? TableId { get; set; }
		public Guid? BookingId { get; set; }
	}
}
