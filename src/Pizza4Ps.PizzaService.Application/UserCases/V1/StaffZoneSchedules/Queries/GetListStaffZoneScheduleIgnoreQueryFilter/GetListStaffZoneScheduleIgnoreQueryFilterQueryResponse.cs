using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneScheduleIgnoreQueryFilter
{
    public class GetListStaffZoneScheduleIgnoreQueryFilterQueryResponse : PaginatedResultDto<StaffZoneScheduleDto>
    {
        public GetListStaffZoneScheduleIgnoreQueryFilterQueryResponse(List<StaffZoneScheduleDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
