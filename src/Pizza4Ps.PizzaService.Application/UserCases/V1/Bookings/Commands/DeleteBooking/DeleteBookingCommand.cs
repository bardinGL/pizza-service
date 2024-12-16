using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.DeleteBooking
{
	public class DeleteBookingCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}

