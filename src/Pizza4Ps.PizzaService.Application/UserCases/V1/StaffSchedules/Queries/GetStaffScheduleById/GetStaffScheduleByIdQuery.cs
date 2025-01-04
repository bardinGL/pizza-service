using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetStaffScheduleById
{
    public class GetStaffScheduleByIdQuery : IRequest<GetStaffScheduleByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
