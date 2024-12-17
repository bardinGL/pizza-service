using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZone
{
    public class GetListStaffZoneQuery : IRequest<GetListStaffZoneQueryResponse>
    {
        public GetListStaffZoneDto GetListStaffZoneDto { get; set; }
    }
}
