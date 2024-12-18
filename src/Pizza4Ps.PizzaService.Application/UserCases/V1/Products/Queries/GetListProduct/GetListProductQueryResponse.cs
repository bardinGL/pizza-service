using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct
{
	public class GetListProductQueryResponse : PaginatedResultDto<ProductDto>
	{
		public GetListProductQueryResponse(List<ProductDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
