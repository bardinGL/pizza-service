using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.DeleteOrderVoucher
{
	public class DeleteOrderVoucherCommandHandler : IRequestHandler<DeleteOrderVoucherCommand>
	{
		private readonly IOrderVoucherService _orderVoucherService;

		public DeleteOrderVoucherCommandHandler(IOrderVoucherService orderVoucherService)
		{
			_orderVoucherService = orderVoucherService;
		}

		public async Task Handle(DeleteOrderVoucherCommand request, CancellationToken cancellationToken)
		{
			await _orderVoucherService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
