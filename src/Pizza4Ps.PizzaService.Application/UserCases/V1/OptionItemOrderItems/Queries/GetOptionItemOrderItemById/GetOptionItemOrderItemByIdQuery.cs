using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById
{
	public class GetOptionItemOrderItemByIdQuery : IRequest<GetOptionItemOrderItemByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
