using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffSchedule
{
    public class GetListStaffScheduleQuery : IRequest<GetListStaffScheduleQueryResponse>
    {
        public GetListStaffScheduleDto GetListStaffScheduleDto { get; set; }
    }
}