using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZoneIgnoreQueryFilter
{
    public class GetListStaffZoneIgnoreQueryFilterQueryResponse : PaginatedResultDto<StaffZoneDto>
    {
        public GetListStaffZoneIgnoreQueryFilterQueryResponse(List<StaffZoneDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
