using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZone
{
	public class GetListZoneQuery : IRequest<GetListZoneQueryResponse>
	{
		public GetListZoneDto GetListZoneDto { get; set; }
	}
}
