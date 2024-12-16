using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.CreateTableBooking
{
	public class CreateTableBookingCommand : IRequest<CreateTableBookingCommandResponse>
	{
		public CreateTableBookingDto CreateTableBookingDto { get; set; }
	}
}
