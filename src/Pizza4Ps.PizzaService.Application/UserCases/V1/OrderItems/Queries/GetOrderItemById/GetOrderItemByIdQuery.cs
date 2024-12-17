using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemById
{
	public class GetOrderItemByIdQuery : IRequest<GetOrderItemByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
