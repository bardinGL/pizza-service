using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTableIgnoreQueryFilter
{
    public class GetListTableIgnoreQueryFilterQuery : IRequest<GetListTableIgnoreQueryFilterQueryResponse>
    {
        public GetListTableIgnoreQueryFilterDto GetListTableIgnoreQueryFilterDto { get; set; }
    }
}

