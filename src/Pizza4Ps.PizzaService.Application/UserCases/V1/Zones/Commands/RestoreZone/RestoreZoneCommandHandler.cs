using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.RestoreZone
{
    public class RestoreZoneCommandHandler : IRequestHandler<RestoreZoneCommand>
    {
        private readonly IZoneService _zoneService;

        public RestoreZoneCommandHandler(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public async Task Handle(RestoreZoneCommand request, CancellationToken cancellationToken)
        {
            await _zoneService.RestoreAsync(request.Ids);
        }
    }
}
