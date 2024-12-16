using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Options;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Queries.GetListOption
{
    public class GetListOptionQuery : IRequest<GetListOptionQueryResponse>
    {
        public GetListOptionDto GetListOptionDto { get; set; }
    }
}
