using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBookingIgnoreQueryFilter
{
    public class GetListBookingIgnoreQueryFilterQueryResponse : PaginatedResultDto<BookingDto>
    {
        public GetListBookingIgnoreQueryFilterQueryResponse(List<BookingDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
