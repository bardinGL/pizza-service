using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking
{
    public class GetListBookingQuery : IRequest<GetListBookingQueryResponse>
    {
        public GetListBookingDto GetListBookingDto { get; set; }
    }
}
