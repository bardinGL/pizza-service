using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProductIgnoreQueryFilter
{
	public class GetListProductIgnoreQueryFilterQuery : IRequest<GetListProductIgnoreQueryFilterQueryResponse>
    {
        public GetListProductIgnoreQueryFilterDto GetListProductIgnoreQueryFilterDto { get; set; }
    }
}
