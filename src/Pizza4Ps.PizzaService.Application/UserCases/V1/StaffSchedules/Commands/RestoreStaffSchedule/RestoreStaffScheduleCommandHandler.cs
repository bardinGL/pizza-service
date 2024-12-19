using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.RestoreStaffSchedule
{
    public class RestoreStaffScheduleCommandHandler : IRequestHandler<RestoreStaffScheduleCommand>
    {
        private readonly IStaffScheduleService _StaffScheduleService;

        public RestoreStaffScheduleCommandHandler(IStaffScheduleService StaffScheduleService)
        {
            _StaffScheduleService = StaffScheduleService;
        }

        public async Task Handle(RestoreStaffScheduleCommand request, CancellationToken cancellationToken)
        {
            await _StaffScheduleService.RestoreAsync(request.Ids);
        }
    }
}
