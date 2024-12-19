using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.RestoreStaffSchedule
{
    public class RestoreStaffScheduleCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
