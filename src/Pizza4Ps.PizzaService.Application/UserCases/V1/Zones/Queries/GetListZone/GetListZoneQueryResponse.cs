using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZone
{
	public class GetListZoneQueryResponse : PaginatedResultDto<ZoneDto>
	{
		public GetListZoneQueryResponse(List<ZoneDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
