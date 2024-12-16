namespace Pizza4Ps.PizzaService.Application.DTOs.TableBookings
{
	public class CreateTableBookingDto
	{
		public DateTime OnholdTime { get; set; }
		public Guid TableId { get; set; }
		public Guid BookingId { get; set; }
	}
}
