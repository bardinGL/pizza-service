using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentById
{
	public class GetPaymentByIdQuery : IRequest<GetPaymentByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
