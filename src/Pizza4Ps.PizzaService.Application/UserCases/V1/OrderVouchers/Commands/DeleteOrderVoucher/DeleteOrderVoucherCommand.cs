using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.DeleteOrderVoucher
{
	public class DeleteOrderVoucherCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
