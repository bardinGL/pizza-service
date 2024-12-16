using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.CreateOrderVoucher
{
	public class CreateOrderVoucherCommand : IRequest<CreateOrderVoucherCommandResponse>
	{
		public CreateOrderVoucherDto CreateOrderVoucherDto { get; set; }
	}
}
