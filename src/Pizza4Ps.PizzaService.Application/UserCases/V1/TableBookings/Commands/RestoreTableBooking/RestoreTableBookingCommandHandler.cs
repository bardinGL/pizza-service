using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.RestoreTableBooking
{
	public class RestoreTableBookingCommandHandler : IRequestHandler<RestoreTableBookingCommand>
	{
		private readonly ITableBookingService _tableBookingService;

		public RestoreTableBookingCommandHandler(ITableBookingService tableBookingService)
		{
			_tableBookingService = tableBookingService;
		}

		public async Task Handle(RestoreTableBookingCommand request, CancellationToken cancellationToken)
		{
			await _tableBookingService.RestoreAsync(request.Ids);
		}
	}
}
