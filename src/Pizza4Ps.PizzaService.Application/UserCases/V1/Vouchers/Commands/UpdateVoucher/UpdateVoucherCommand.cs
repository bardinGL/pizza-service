using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.UpdateVoucher
{
	public class UpdateVoucherCommand : IRequest<UpdateVoucherCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateVoucherDto UpdateVoucherDto { get; set; }
	}
}
