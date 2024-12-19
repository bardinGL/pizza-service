using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.CreateStaffSchedule
{
    public class CreateStaffScheduleCommand : IRequest<CreateStaffScheduleCommandResponse>
    {
        public CreateStaffScheduleDto CreateStaffScheduleDto { get; set; }
    }
}
