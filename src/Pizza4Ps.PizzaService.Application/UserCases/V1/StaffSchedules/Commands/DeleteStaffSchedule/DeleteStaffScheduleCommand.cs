using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.DeleteStaffSchedule
{
    public class DeleteStaffScheduleCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
