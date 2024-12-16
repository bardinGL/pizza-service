using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking
{
    public class GetListBookingQueryResponse : PaginatedResultDto<BookingDto>
    {
        public GetListBookingQueryResponse(List<BookingDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
