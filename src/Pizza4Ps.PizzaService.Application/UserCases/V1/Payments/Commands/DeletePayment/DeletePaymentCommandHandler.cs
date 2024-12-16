using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.DeletePayment
{
	public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand>
	{
		private readonly IPaymentService _PaymentService;

		public DeletePaymentCommandHandler(IPaymentService Paymentservice)
		{
			_PaymentService = Paymentservice;
		}

		public async Task Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
		{
			await _PaymentService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
