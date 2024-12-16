using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.DeleteZone
{
    public class DeleteZoneCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
