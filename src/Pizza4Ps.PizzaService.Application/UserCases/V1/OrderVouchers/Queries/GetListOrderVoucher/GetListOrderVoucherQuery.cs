using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucher
{
	public class GetListOrderVoucherQuery : IRequest<GetListOrderVoucherQueryResponse>
	{
		public GetListOrderVoucherDto GetListOrderVoucherDto { get; set; }
	}
}
