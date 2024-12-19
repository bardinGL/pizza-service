using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Bookings
{
	public class GetListBookingIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public DateTime? BookingDate { get; set; }
		public int? GuestCount { get; set; }
		public string? Status { get; set; }
		public Guid? CustomerId { get; set; }
	}
}
