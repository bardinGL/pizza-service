using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule
{
    public class GetListStaffZoneScheduleQueryResponse : PaginatedResultDto<StaffZoneScheduleDto>
    {
        public GetListStaffZoneScheduleQueryResponse(List<StaffZoneScheduleDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
