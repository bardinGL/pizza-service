using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOptionIgnoreQueryFilter
{
	public class GetListProductOptionIgnoreQueryFilterQuery : IRequest<GetListProductOptionIgnoreQueryFilterQueryResponse>
	{
		public GetListProductOptionIgnoreQueryFilterDto GetListProductOptionIgnoreQueryFilterDto { get; set; }
	}
}
