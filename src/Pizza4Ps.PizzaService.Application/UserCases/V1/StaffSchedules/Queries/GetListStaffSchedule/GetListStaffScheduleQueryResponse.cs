using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffSchedule
{
    public class GetListStaffScheduleQueryResponse : PaginatedResultDto<StaffScheduleDto>
    {
        public GetListStaffScheduleQueryResponse(List<StaffScheduleDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
