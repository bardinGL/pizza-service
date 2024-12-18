using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOptionIgnoreQueryFilter
{
	public class GetListProductOptionIgnoreQueryFilterQueryResponse : PaginatedResultDto<ProductOptionDto>
	{
		public GetListProductOptionIgnoreQueryFilterQueryResponse(List<ProductOptionDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
