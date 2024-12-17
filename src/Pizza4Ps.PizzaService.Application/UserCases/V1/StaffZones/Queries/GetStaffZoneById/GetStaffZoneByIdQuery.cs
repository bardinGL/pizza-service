using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetStaffZoneById
{
    public class GetStaffZoneByIdQuery : IRequest<GetStaffZoneByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
