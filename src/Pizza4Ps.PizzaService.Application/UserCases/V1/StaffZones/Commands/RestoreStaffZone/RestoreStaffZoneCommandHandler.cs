using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.RestoreStaffZone
{
    public class RestoreStaffZoneCommandHandler : IRequestHandler<RestoreStaffZoneCommand>
    {
        private readonly IStaffZoneService _StaffZoneService;

        public RestoreStaffZoneCommandHandler(IStaffZoneService StaffZoneService)
        {
            _StaffZoneService = StaffZoneService;
        }

        public async Task Handle(RestoreStaffZoneCommand request, CancellationToken cancellationToken)
        {
            await _StaffZoneService.RestoreAsync(request.Ids);
        }
    }
}
