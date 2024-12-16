using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable
{
    public class GetListTableQueryResponse : PaginatedResultDto<TableDto>
    {
        public GetListTableQueryResponse(List<TableDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
