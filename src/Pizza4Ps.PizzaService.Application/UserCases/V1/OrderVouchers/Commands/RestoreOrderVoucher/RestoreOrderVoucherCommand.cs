using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.RestoreOrderVoucher
{
	public class RestoreOrderVoucherCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
