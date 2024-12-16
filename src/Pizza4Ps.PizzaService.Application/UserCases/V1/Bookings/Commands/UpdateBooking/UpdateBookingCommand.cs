using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.UpdateBooking
{
	public class UpdateBookingCommand : IRequest<UpdateBookingCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateBookingDto UpdateBookingDto { get; set; }
	}
}

