using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneScheduleIgnoreQueryFilter
{
    public class GetListStaffZoneScheduleIgnoreQueryFilterQuery : IRequest<GetListStaffZoneScheduleIgnoreQueryFilterQueryResponse>
    {
        public GetListStaffZoneScheduleIgnoreQueryFilterDto GetListStaffZoneScheduleIgnoreQueryFilterDto { get; set; }
    }
}
