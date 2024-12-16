using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.DeleteBooking
{
	internal class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
	{
		private readonly IBookingService _bookingService;

		public DeleteBookingCommandHandler(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		public async Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
		{
			await _bookingService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
