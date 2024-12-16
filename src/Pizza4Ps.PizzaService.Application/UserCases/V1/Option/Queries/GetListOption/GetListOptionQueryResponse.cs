using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Options;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Queries.GetListOption
{
    public class GetListOptionQueryResponse : PaginatedResultDto<OptionDto>
    {
        public GetListOptionQueryResponse(List<OptionDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
