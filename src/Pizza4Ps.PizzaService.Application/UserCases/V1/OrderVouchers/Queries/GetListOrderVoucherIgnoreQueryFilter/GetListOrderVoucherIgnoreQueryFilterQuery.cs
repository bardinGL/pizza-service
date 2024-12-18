using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucherIgnoreQueryFilter
{
	public class GetListOrderVoucherIgnoreQueryFilterQuery : IRequest<GetListOrderVoucherIgnoreQueryFilterQueryResponse>
	{
		public GetListOrderVoucherIgnoreQueryFilterDto GetListOrderVoucherIgnoreQueryFilterDto { get; set; }
	}
}
