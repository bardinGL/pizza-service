using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBookingIgnoreQueryFilter
{
    public class GetListBookingIgnoreQueryFilterQuery : IRequest<GetListBookingIgnoreQueryFilterQueryResponse>
    {
        public GetListBookingIgnoreQueryFilterDto GetListBookingIgnoreQueryFilterDto { get; set; }
    }
}
