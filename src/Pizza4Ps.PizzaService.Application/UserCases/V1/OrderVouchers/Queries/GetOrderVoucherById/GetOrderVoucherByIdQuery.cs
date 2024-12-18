using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetOrderVoucherById
{
	public class GetOrderVoucherByIdQuery : IRequest<GetOrderVoucherByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
