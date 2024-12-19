using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.CreateStaffSchedule
{
    public class CreateStaffScheduleCommandHandler : IRequestHandler<CreateStaffScheduleCommand, CreateStaffScheduleCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffScheduleService _StaffScheduleService;

        public CreateStaffScheduleCommandHandler(IMapper mapper, IStaffScheduleService StaffScheduleService)
        {
            _mapper = mapper;
            _StaffScheduleService = StaffScheduleService;
        }

        public async Task<CreateStaffScheduleCommandResponse> Handle(CreateStaffScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffScheduleService.CreateAsync(
                request.CreateStaffScheduleDto.SchedualDate,
                request.CreateStaffScheduleDto.ShiftStart,
                request.CreateStaffScheduleDto.ShiftEnd,
                request.CreateStaffScheduleDto.Status,
                request.CreateStaffScheduleDto.StaffId,
                request.CreateStaffScheduleDto.ZoneId
                );
            return new CreateStaffScheduleCommandResponse
            {
                Id = result
            };
        }
    }
}
