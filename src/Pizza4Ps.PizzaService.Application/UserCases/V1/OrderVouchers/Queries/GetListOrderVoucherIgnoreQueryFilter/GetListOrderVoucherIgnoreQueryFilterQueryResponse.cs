using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucherIgnoreQueryFilter
{
	public class GetListOrderVoucherIgnoreQueryFilterQueryResponse : PaginatedResultDto<OrderVoucherDto>
	{
		public GetListOrderVoucherIgnoreQueryFilterQueryResponse(List<OrderVoucherDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
