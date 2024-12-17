using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.UpdateStaffZone
{
    public class UpdateStaffZoneCommand : IRequest<UpdateStaffZoneCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateStaffZoneDto UpdateStaffZoneDto { get; set; }
    }
}
