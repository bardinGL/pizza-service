using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZoneIgnoreQueryFilter
{
	public class GetListZoneIgnoreQueryFilterQuery : IRequest<GetListZoneIgnoreQueryFilterQueryResponse>
	{
		public GetListZoneIgnoreQueryFilterDto GetListZoneIgnoreQueryFilterDto { get; set; }
	}
}
