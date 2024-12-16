using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.RestorePayment
{
	public class RestorePaymentCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
