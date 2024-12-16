using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, UpdateZoneCommandResponse>
    {
        private readonly IZoneService _zoneService;

        public UpdateZoneCommandHandler(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public async Task<UpdateZoneCommandResponse> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _zoneService.UpdateAsync(
                request.Id,
                request.UpdateZoneDto.Name,
                request.UpdateZoneDto.Capacity,
                request.UpdateZoneDto.Description,
                request.UpdateZoneDto.Status);
            return new UpdateZoneCommandResponse
            {
                Id = result
            };
        }
    }
}
