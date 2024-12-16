using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Options;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionIgnoreQueryFilter
{
	public class GetListOptionIgnoreQueryFilterQuery : IRequest<GetListOptionIgnoreQueryFilterQueryResponse>
	{
		public GetListOptionIgnoreQueryFilterDto GetListOptionIgnoreQueryFilterDto { get; set; }
	}
}
