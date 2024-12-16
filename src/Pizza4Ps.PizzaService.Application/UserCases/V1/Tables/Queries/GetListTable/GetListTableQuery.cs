using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable
{
    public class GetListTableQuery : IRequest<GetListTableQueryResponse>
    {
        public GetListTableDto GetListTableDto { get; set; }
    }
}
