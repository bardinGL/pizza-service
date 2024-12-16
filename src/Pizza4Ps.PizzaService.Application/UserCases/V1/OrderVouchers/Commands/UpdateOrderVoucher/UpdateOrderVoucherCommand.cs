using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.UpdateOrderVoucher
{
	public class UpdateOrderVoucherCommand : IRequest<UpdateOrderVoucherCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateOrderVoucherDto UpdateOrderVoucherDto { get; set; }
	}
}
