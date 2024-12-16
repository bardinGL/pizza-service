using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.UpdateVoucher
{
	public class UpdateVoucherCommandHandler : IRequestHandler<UpdateVoucherCommand, UpdateVoucherCommandResponse>
	{
		private readonly IVoucherService _voucherService;

		public UpdateVoucherCommandHandler(IVoucherService voucherService)
		{
			_voucherService = voucherService;
		}

		public async Task<UpdateVoucherCommandResponse> Handle(UpdateVoucherCommand request, CancellationToken cancellationToken)
		{
			var result = await _voucherService.UpdateAsync(
				request.Id,
				request.UpdateVoucherDto.Code,
				request.UpdateVoucherDto.DiscountType,
				request.UpdateVoucherDto.ExpiryDate);
			return new UpdateVoucherCommandResponse
			{
				Id = result
			};
		}
	}
}
