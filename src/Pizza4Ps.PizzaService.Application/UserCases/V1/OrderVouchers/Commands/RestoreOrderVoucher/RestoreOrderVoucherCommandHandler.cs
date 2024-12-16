using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.RestoreOrderVoucher
{
	public class RestoreOrderVoucherCommandHandler : IRequestHandler<RestoreOrderVoucherCommand>
	{
		private readonly IOrderVoucherService _orderVoucherService;

		public RestoreOrderVoucherCommandHandler(IOrderVoucherService orderVoucherService)
		{
			_orderVoucherService = orderVoucherService;
		}

		public async Task Handle(RestoreOrderVoucherCommand request, CancellationToken cancellationToken)
		{
			await _orderVoucherService.RestoreAsync(request.Ids);
		}
	}
}
