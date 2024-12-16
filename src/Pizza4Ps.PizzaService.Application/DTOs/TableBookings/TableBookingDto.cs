using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.TableBookings
{
	public class TableBookingDto
	{
		public Guid Id { get; set; }
		public DateTime OnholdTime { get; set; }
		public Guid TableId { get; set; }
		public Guid BookingId { get; set; }

		public virtual Table Table { get; set; }
		public virtual Booking Booking { get; set; }
	}
}
