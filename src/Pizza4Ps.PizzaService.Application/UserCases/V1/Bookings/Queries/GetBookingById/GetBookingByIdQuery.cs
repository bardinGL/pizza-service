using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IRequest<GetBookingByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}

