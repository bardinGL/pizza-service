using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.DeleteStaffZoneSchedule
{
    public class DeleteStaffZoneScheduleCommandHandler : IRequestHandler<DeleteStaffZoneScheduleCommand>
    {
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public DeleteStaffZoneScheduleCommandHandler(IStaffZoneScheduleService StaffZoneScheduleservice)
        {
            _StaffZoneScheduleService = StaffZoneScheduleservice;
        }

        public async Task Handle(DeleteStaffZoneScheduleCommand request, CancellationToken cancellationToken)
        {
            await _StaffZoneScheduleService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
