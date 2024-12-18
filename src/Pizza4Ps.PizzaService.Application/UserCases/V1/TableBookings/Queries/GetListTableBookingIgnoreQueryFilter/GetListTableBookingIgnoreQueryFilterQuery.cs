using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBookingIgnoreQueryFilter
{
	public class GetListTableBookingIgnoreQueryFilterQuery : IRequest<GetListTableBookingIgnoreQueryFilterQueryResponse>
	{
		public GetListTableBookingIgnoreQueryFilterDto GetListTableBookingIgnoreQueryFilterDto { get; set; }
	}
}
