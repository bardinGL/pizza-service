using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommand : IRequest<UpdateZoneCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateZoneDto UpdateZoneDto { get; set; }
    }
}
