using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetTableBookingById
{
	public class GetTableBookingByIdQuery : IRequest<GetTableBookingByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
