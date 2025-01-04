using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.UpdateStaffSchedule
{
    public class UpdateStaffScheduleCommand : IRequest<UpdateStaffScheduleCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateStaffScheduleDto UpdateStaffScheduleDto { get; set; }
    }
}
