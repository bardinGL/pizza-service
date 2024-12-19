using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOption
{
	public class GetListProductOptionQueryResponse : PaginatedResultDto<ProductOptionDto>
	{
		public GetListProductOptionQueryResponse(List<ProductOptionDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
