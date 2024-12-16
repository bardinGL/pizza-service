using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct
{
    public class GetListProductQuery : IRequest<GetListProductQueryResponse>
    {
        public GetListProductDto GetListProductDto { get; set; }
    }
}
