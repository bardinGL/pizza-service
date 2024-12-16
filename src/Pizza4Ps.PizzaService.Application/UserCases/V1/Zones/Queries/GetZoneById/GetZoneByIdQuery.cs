using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetZoneById
{
	public class GetZoneByIdQuery : IRequest<GetZoneByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
