using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetVoucherById
{
	public class GetVoucherByIdQuery : IRequest<GetVoucherByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
