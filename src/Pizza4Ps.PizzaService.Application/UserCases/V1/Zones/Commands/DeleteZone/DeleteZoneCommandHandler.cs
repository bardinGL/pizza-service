using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.DeleteZone
{
    public class DeleteZoneCommandHandler : IRequestHandler<DeleteZoneCommand>
    {
        private readonly IZoneService _zoneService;

        public DeleteZoneCommandHandler(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public async Task Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            await _zoneService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
