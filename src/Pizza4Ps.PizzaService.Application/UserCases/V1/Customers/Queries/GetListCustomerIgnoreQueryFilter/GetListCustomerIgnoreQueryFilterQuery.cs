using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;
using Pizza4Ps.PizzaService.Application.DTOs.Products;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQuery : IRequest<GetListCustomerIgnoreQueryFilterQueryResponse>
    {
        public GetListCustomerIgnoreQueryFilterDto GetListCustomerIgnoreQueryFilterDto { get; set; }
    }
}
