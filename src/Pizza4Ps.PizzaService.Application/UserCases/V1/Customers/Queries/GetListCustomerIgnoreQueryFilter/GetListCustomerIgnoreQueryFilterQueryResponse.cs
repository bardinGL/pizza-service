using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQueryResponse : PaginatedResultDto<CustomerDto>
    {
        public GetListCustomerIgnoreQueryFilterQueryResponse(List<CustomerDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
