using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.CreateStaffZone
{
    public class CreateStaffZoneCommandHandler : IRequestHandler<CreateStaffZoneCommand, CreateStaffZoneCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneService _StaffZoneService;

        public CreateStaffZoneCommandHandler(IMapper mapper, IStaffZoneService StaffZoneService)
        {
            _mapper = mapper;
            _StaffZoneService = StaffZoneService;
        }

        public async Task<CreateStaffZoneCommandResponse> Handle(CreateStaffZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneService.CreateAsync(
                request.CreateStaffZoneDto.ShiftStart,
                request.CreateStaffZoneDto.ShiftEnd,
                request.CreateStaffZoneDto.Note,
                request.CreateStaffZoneDto.StaffId,
                request.CreateStaffZoneDto.ZoneId
                );
            return new CreateStaffZoneCommandResponse
            {
                Id = result
            };
        }
    }
}
