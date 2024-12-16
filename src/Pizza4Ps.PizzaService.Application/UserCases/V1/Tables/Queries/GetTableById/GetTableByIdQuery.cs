using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableById
{
    public class GetTableByIdQuery : IRequest<GetTableByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
