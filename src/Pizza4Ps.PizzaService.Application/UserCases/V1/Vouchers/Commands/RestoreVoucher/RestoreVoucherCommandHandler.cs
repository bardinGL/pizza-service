using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.RestoreProduct;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.RestoreVoucher
{
	public class RestoreVoucherCommandHandler : IRequestHandler<RestoreVoucherCommand>
	{
		private readonly IVoucherService _voucherService;

		public RestoreVoucherCommandHandler(IVoucherService voucherService)
		{
			_voucherService = voucherService;
		}

		public async Task Handle(RestoreVoucherCommand request, CancellationToken cancellationToken)
		{
			await _voucherService.RestoreAsync(request.Ids);
		}
	}
}
