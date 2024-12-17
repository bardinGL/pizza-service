using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItem
{
	public class GetListOptionItemOrderItemQuery : IRequest<GetListOptionItemOrderItemQueryResponse>
	{
		public GetListOptionItemOrderItemDto GetListOptionItemOrderItemDto { get; set; }
	}
}
