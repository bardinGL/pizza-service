using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter
{
	public class GetListOptionItemOrderItemIgnoreQueryFilterQuery : IRequest<GetListOptionItemOrderItemIgnoreQueryFilterQueryResponse>
	{
		public GetListOptionItemOrderItemIgnoreQueryFilterDto GetListOptionItemOrderItemIgnoreQueryFilterDto { get; set; }
	}
}
