using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.UpdateTableBooking
{
	public class UpdateTableBookingCommandHandler : IRequestHandler<UpdateTableBookingCommand, UpdateTableBookingCommandResponse>
	{
		private readonly ITableBookingService _tableBookingService;

		public UpdateTableBookingCommandHandler(ITableBookingService tableBookingService)
		{
			_tableBookingService = tableBookingService;
		}

		public async Task<UpdateTableBookingCommandResponse> Handle(UpdateTableBookingCommand request, CancellationToken cancellationToken)
		{
			var result = await _tableBookingService.UpdateAsync(
				request.Id,
				request.UpdateTableBookingDto.OnholdTime,
				request.UpdateTableBookingDto.TableId,
				request.UpdateTableBookingDto.BookingId);
			return new UpdateTableBookingCommandResponse
			{
				Id = result
			};
		}
	}
}
