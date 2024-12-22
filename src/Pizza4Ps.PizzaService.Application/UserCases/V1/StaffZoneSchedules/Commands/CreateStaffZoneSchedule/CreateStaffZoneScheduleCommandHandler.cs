using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.CreateStaffZoneSchedule
{
    public class CreateStaffZoneScheduleCommandHandler : IRequestHandler<CreateStaffZoneScheduleCommand, CreateStaffZoneScheduleCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleService _StaffZoneScheduleService;

        public CreateStaffZoneScheduleCommandHandler(IMapper mapper, IStaffZoneScheduleService StaffZoneScheduleService)
        {
            _mapper = mapper;
            _StaffZoneScheduleService = StaffZoneScheduleService;
        }

        public async Task<CreateStaffZoneScheduleCommandResponse> Handle(CreateStaffZoneScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneScheduleService.CreateAsync(
                request.CreateStaffZoneScheduleDto.DayofWeek,
                request.CreateStaffZoneScheduleDto.ShiftStart,
                request.CreateStaffZoneScheduleDto.ShiftEnd,
                request.CreateStaffZoneScheduleDto.Note,
                request.CreateStaffZoneScheduleDto.StaffId,
                request.CreateStaffZoneScheduleDto.ZoneId,
                request.CreateStaffZoneScheduleDto.WorkingTimeId

                );
            return new CreateStaffZoneScheduleCommandResponse
            {
                Id = result
            };
        }
    }
}
