using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBooking
{
	public class GetListTableBookingQueryResponse : PaginatedResultDto<TableBookingDto>
	{
		public GetListTableBookingQueryResponse(List<TableBookingDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
