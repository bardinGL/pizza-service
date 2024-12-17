using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZoneIgnoreQueryFilter
{
    public class GetListStaffZoneIgnoreQueryFilterQuery : IRequest<GetListStaffZoneIgnoreQueryFilterQueryResponse>
    {
        public GetListStaffZoneIgnoreQueryFilterDto GetListStaffZoneIgnoreQueryFilterDto { get; set; }
    }
}
