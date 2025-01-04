using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.UpdateStaffZoneSchedule
{
    public class UpdateStaffZoneScheduleCommand : IRequest<UpdateStaffZoneScheduleCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateStaffZoneScheduleDto UpdateStaffZoneScheduleDto { get; set; }
    }
}

