using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZone
{
    public class GetListStaffZoneQueryResponse : PaginatedResultDto<StaffZoneDto>
    {
        public GetListStaffZoneQueryResponse(List<StaffZoneDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}

