using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking
{
	public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreateBookingCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBookingService _bookingService;

		public CreateBookingCommandHandler(IMapper mapper, IBookingService bookingService)
		{
			_mapper = mapper;
			_bookingService = bookingService;
		}

		public async Task<CreateBookingCommandResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
		{
			var result = await _bookingService.CreateAsync(
				request.CreateBookingDto.BookingDate,
				request.CreateBookingDto.GuestCount,
				request.CreateBookingDto.Status,
				request.CreateBookingDto.CustomerId);
			return new CreateBookingCommandResponse
			{
				Id = result
			};
		}
	}
}
