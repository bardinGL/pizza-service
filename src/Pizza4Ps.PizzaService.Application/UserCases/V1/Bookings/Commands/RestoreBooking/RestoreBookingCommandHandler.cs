using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.RestoreBooking
{
	public class RestoreBookingCommandHandler
	{
		private readonly IBookingService _bookingService;

		public RestoreBookingCommandHandler(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		public async Task Handle(RestoreBookingCommand request, CancellationToken cancellationToken)
		{
			await _bookingService.RestoreAsync(request.Ids);
		}
	}
}
