using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetStaffZoneScheduleById
{
    public class GetStaffZoneScheduleByIdQuery : IRequest<GetStaffZoneScheduleByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
