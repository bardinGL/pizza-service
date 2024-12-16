using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.UpdateTableBooking
{
	public class UpdateTableBookingCommand : IRequest<UpdateTableBookingCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateTableBookingDto UpdateTableBookingDto { get; set; }
	}
}
