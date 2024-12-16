namespace Pizza4Ps.PizzaService.Application.DTOs.TableBookings
{
	public class UpdateTableBookingDto
	{
		public DateTime OnholdTime { get; set; }
		public Guid TableId { get; set; }
		public Guid BookingId { get; set; }
	}
}
