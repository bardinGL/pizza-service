using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.UpdatePayment
{
	public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, UpdatePaymentCommandResponse>
	{
		private readonly IPaymentService _PaymentService;

		public UpdatePaymentCommandHandler(IPaymentService PaymentService)
		{
			_PaymentService = PaymentService;
		}

		public async Task<UpdatePaymentCommandResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
		{
			var result = await _PaymentService.UpdateAsync(
				request.Id,
				request.UpdatePaymentDto.Amount,
				request.UpdatePaymentDto.PaymentMethod,
				request.UpdatePaymentDto.Status,
				request.UpdatePaymentDto.OrderId);
			return new UpdatePaymentCommandResponse
			{
				Id = result
			};
		}
	}
}
