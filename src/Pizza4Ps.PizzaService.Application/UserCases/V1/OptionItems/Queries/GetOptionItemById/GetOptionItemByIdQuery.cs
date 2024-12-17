using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetOptionItemById
{
	public class GetOptionItemByIdQuery : IRequest<GetOptionItemByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
