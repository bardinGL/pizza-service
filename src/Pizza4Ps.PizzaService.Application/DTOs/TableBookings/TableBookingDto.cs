using Pizza4Ps.PizzaService.Application.DTOs.Bookings;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.TableBookings
{
	public class TableBookingDto
	{
		public Guid Id { get; set; }
		public DateTime OnholdTime { get; set; }
		public Guid TableId { get; set; }
		public Guid BookingId { get; set; }

		public virtual TableDto Table { get; set; }
		public virtual BookingDto Booking { get; set; }
	}
}
