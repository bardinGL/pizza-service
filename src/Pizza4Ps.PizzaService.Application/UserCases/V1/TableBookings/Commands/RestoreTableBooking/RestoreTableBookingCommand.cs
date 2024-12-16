using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.RestoreTableBooking
{
	public class RestoreTableBookingCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
