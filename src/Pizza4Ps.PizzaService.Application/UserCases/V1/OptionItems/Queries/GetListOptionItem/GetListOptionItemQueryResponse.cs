using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItem
{
	public class GetListOptionItemQueryResponse : PaginatedResultDto<OptionItemDto>
	{
		public GetListOptionItemQueryResponse(List<OptionItemDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
