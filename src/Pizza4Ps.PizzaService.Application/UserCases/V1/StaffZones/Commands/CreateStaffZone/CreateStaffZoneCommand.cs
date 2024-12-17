using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.CreateStaffZone
{
    public class CreateStaffZoneCommand : IRequest<CreateStaffZoneCommandResponse>
    {
        public CreateStaffZoneDto CreateStaffZoneDto { get; set; }
    }
}
