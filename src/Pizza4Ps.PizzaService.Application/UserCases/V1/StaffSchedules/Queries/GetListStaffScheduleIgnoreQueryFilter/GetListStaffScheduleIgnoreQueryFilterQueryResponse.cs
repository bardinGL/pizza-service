using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffScheduleIgnoreQueryFilter
{
    public class GetListStaffScheduleIgnoreQueryFilterQueryResponse : PaginatedResultDto<StaffScheduleDto>
    {
        public GetListStaffScheduleIgnoreQueryFilterQueryResponse(List<StaffScheduleDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
