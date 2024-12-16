using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.DeleteTable;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.DeleteTableBooking
{
	public class DeleteTableBookingCommandHandler : IRequestHandler<DeleteTableCommand>
	{
		private readonly ITableBookingService _tableBookingService;

		public DeleteTableBookingCommandHandler(ITableBookingService tableBookingService)
		{
			_tableBookingService = tableBookingService;
		}

		public async Task Handle(DeleteTableCommand request, CancellationToken cancellationToken)
		{
			await _tableBookingService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
