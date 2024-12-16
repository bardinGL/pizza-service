using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Queries.GetListOrderIgnoreQueryFilter
{
    public class GetListOrderIgnoreQueryFilterQuery : IRequest<GetListOrderIgnoreQueryFilterQueryResponse>
    {
        public GetListOrderIgnoreQueryFilterDto GetListOrderIgnoreQueryFilterDto { get; set; }
    }
}
