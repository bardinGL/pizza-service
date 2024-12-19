using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.RestoreStaffZoneSchedule
{
    public class RestoreStaffZoneScheduleCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
