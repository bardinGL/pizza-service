using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.UpdateBooking
{
	public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, UpdateBookingCommandResponse>
	{
		private readonly IBookingService _bookingService;

		public UpdateBookingCommandHandler(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		public async Task<UpdateBookingCommandResponse> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
		{
			var result = await _bookingService.UpdateAsync(
				request.Id,
				request.UpdateBookingDto.BookingDate,
				request.UpdateBookingDto.GuestCount,
				request.UpdateBookingDto.Status,
				request.UpdateBookingDto.CustomerId);
			return new UpdateBookingCommandResponse
			{
				Id = result
			};
		}
	}
}
