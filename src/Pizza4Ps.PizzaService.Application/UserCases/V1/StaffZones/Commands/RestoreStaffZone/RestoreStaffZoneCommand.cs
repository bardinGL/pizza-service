using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.RestoreStaffZone
{
    public class RestoreStaffZoneCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}