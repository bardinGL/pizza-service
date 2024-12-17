using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItem
{
	public class GetListOptionItemQuery : IRequest<GetListOptionItemQueryResponse>
	{
		public GetListOptionItemDto GetListOptionItemDto { get; set; }
	}
}
