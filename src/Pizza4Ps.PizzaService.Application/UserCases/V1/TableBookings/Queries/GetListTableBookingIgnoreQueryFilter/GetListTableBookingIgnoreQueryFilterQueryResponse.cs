using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBookingIgnoreQueryFilter
{
	public class GetListTableBookingIgnoreQueryFilterQueryResponse : PaginatedResultDto<TableBookingDto>
	{
		public GetListTableBookingIgnoreQueryFilterQueryResponse(List<TableBookingDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
