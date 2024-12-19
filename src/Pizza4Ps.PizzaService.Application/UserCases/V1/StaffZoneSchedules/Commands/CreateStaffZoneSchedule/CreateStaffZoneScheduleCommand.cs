using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.CreateStaffZoneSchedule
{
    public class CreateStaffZoneScheduleCommand : IRequest<CreateStaffZoneScheduleCommandResponse>
    {
        public CreateStaffZoneScheduleDto CreateStaffZoneScheduleDto { get; set; }
    }
}
