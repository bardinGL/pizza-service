using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.RestoreStaffZoneSchedule
{
    public class RestoreStaffZoneScheduleCommandHandler : IRequestHandler<RestoreStaffZoneScheduleCommand>
    {
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public RestoreStaffZoneScheduleCommandHandler(IStaffZoneScheduleService StaffZoneScheduleService)
        {
            _StaffZoneScheduleService = StaffZoneScheduleService;
        }

        public async Task Handle(RestoreStaffZoneScheduleCommand request, CancellationToken cancellationToken)
        {
            await _StaffZoneScheduleService.RestoreAsync(request.Ids);
        }
    }
}
