using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZoneIgnoreQueryFilter
{
	public class GetListZoneIgnoreQueryFilterQueryResponse : PaginatedResultDto<ZoneDto>
	{
		public GetListZoneIgnoreQueryFilterQueryResponse(List<ZoneDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
