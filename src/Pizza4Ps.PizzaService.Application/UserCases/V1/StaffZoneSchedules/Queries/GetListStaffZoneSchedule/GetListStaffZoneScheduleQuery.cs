using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule
{
    public class GetListStaffZoneScheduleQuery : IRequest<GetListStaffZoneScheduleQueryResponse>
    {
        public GetListStaffZoneScheduleDto GetListStaffZoneScheduleDto { get; set; }
    }
}