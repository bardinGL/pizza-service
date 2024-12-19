using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBooking
{
	public class GetListTableBookingQuery : IRequest<GetListTableBookingQueryResponse>
	{
		public GetListTableBookingDto GetListTableBookingDto { get; set; }
	}
}