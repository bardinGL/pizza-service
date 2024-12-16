using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Queries.GetListOrderIgnoreQueryFilter
{
    public class GetListOrderIgnoreQueryFilterQueryResponse : PaginatedResultDto<OrderDto>
    {
        public GetListOrderIgnoreQueryFilterQueryResponse(List<OrderDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
