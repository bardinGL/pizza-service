using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePayment
{
	public class CreatePaymentCommand : IRequest<CreatePaymentCommandResponse>
	{
		public CreatePaymentDto CreatePaymentDto { get; set; }
	}
}
