using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.UpdatePayment
{
	public class UpdatePaymentCommand : IRequest<UpdatePaymentCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdatePaymentDto UpdatePaymentDto { get; set; }
	}
}
