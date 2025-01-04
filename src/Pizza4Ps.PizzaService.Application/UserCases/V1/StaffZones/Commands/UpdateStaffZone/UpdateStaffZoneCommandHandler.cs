using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.UpdateStaffZone
{
    public class UpdateStaffZoneCommandHandler : IRequestHandler<UpdateStaffZoneCommand, UpdateStaffZoneCommandResponse>
    {
        private readonly IStaffZoneService _StaffZoneService;

        public UpdateStaffZoneCommandHandler(IStaffZoneService StaffZoneService)
        {
            _StaffZoneService = StaffZoneService;
        }

        public async Task<UpdateStaffZoneCommandResponse> Handle(UpdateStaffZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _StaffZoneService.UpdateAsync(
                request.Id,
                request.UpdateStaffZoneDto.ShiftStart,
                request.UpdateStaffZoneDto.ShiftEnd,
                request.UpdateStaffZoneDto.Note,
                request.UpdateStaffZoneDto.StaffId,
                request.UpdateStaffZoneDto.ZoneId
                );
            return new UpdateStaffZoneCommandResponse
            {
                Id = result
            };
        }
    }
}
