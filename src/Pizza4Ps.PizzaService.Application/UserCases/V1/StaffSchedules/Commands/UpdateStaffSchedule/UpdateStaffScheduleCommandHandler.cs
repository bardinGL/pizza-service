using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.UpdateStaffSchedule;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.UpdateStaffSchedule
{
    public class UpdateStaffScheduleCommandHandler : IRequestHandler<UpdateStaffScheduleCommand, UpdateStaffScheduleCommandResponse>
    {
        private readonly IStaffScheduleService _StaffScheduleService;

        public UpdateStaffScheduleCommandHandler(IStaffScheduleService StaffScheduleService)
        {
            _StaffScheduleService = StaffScheduleService;
        }

        public async Task<UpdateStaffScheduleCommandResponse> Handle(UpdateStaffScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffScheduleService.UpdateAsync(
                request.Id,
                request.UpdateStaffScheduleDto.SchedualDate,
                request.UpdateStaffScheduleDto.ShiftStart,
                request.UpdateStaffScheduleDto.ShiftEnd,
                request.UpdateStaffScheduleDto.Status,
                request.UpdateStaffScheduleDto.StaffId,
                request.UpdateStaffScheduleDto.ZoneId);
            return new UpdateStaffScheduleCommandResponse
            {
                Id = result
            };
        }
    }
}
