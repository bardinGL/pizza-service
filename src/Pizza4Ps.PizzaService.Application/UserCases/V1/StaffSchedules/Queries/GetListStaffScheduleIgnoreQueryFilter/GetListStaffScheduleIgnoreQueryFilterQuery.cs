using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffScheduleIgnoreQueryFilter
{
    public class GetListStaffScheduleIgnoreQueryFilterQuery : IRequest<GetListStaffScheduleIgnoreQueryFilterQueryResponse>
    {
        public GetListStaffScheduleIgnoreQueryFilterDto GetListStaffScheduleIgnoreQueryFilterDto { get; set; }
    }
}

