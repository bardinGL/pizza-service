using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTableIgnoreQueryFilter
{
    public class GetListTableIgnoreQueryFilterQueryResponse : PaginatedResultDto<TableDto>
    {
        public GetListTableIgnoreQueryFilterQueryResponse(List<TableDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
