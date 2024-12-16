using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProductIgnoreQueryFilter
{
	public class GetListProductIgnoreQueryFilterQueryResponse : PaginatedResultDto<ProductDto>
	{
		public GetListProductIgnoreQueryFilterQueryResponse(List<ProductDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
