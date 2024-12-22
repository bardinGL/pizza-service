using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.UpdateStaffZoneSchedule
{
    public class UpdateStaffZoneScheduleCommandHandler : IRequestHandler<UpdateStaffZoneScheduleCommand, UpdateStaffZoneScheduleCommandResponse>
    {
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public UpdateStaffZoneScheduleCommandHandler(IStaffZoneScheduleService StaffZoneScheduleService)
        {
            _StaffZoneScheduleService = StaffZoneScheduleService;
        }

        public async Task<UpdateStaffZoneScheduleCommandResponse> Handle(UpdateStaffZoneScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneScheduleService.UpdateAsync(
                request.Id,
                request.UpdateStaffZoneScheduleDto.DayofWeek,
                request.UpdateStaffZoneScheduleDto.ShiftStart,
                request.UpdateStaffZoneScheduleDto.ShiftEnd,
                request.UpdateStaffZoneScheduleDto.Note,
                request.UpdateStaffZoneScheduleDto.StaffId,
                request.UpdateStaffZoneScheduleDto.ZoneId,
                request.UpdateStaffZoneScheduleDto.WorkingTimeId
                );
            return new UpdateStaffZoneScheduleCommandResponse
            {
                Id = result
            };
        }
    }
}
