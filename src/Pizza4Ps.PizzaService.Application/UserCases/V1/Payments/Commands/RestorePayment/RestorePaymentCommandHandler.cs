using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.RestorePayment
{
	public class RestorePaymentCommandHandler : IRequestHandler<RestorePaymentCommand>
	{
		private readonly IPaymentService _PaymentService;

		public RestorePaymentCommandHandler(IPaymentService PaymentService)
		{
			_PaymentService = PaymentService;
		}

		public async Task Handle(RestorePaymentCommand request, CancellationToken cancellationToken)
		{
			await _PaymentService.RestoreAsync(request.Ids);
		}
	}
}
