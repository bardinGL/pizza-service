using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.CreateZone
{
    public class CreateZoneCommand : IRequest<CreateZoneCommandResponse>
    {
        public CreateZoneDto CreateZoneDto { get; set; }
    }
}
