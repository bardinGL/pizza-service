using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.DeleteTableBooking
{
	public class DeleteTableBookingCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
