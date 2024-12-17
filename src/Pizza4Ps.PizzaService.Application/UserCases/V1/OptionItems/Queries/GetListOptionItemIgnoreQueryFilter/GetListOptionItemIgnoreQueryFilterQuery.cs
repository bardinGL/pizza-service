using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItemIgnoreQueryFilter
{
	public class GetListOptionItemIgnoreQueryFilterQuery : IRequest<GetListOptionItemIgnoreQueryFilterQueryResponse>
	{
		public GetListOptionItemIgnoreQueryFilterDto GetListOptionItemIgnoreQueryFilterDto { get; set; }
	}
}
