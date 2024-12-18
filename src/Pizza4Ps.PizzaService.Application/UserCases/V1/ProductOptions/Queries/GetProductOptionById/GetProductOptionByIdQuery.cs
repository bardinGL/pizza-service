using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetProductOptionById
{
	public class GetProductOptionByIdQuery : IRequest<GetProductOptionByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
