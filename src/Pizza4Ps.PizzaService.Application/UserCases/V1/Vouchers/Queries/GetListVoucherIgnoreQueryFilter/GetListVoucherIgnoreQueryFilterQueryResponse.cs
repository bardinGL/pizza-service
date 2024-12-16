using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
	public class GetListVoucherIgnoreQueryFilterQueryResponse : PaginatedResultDto<VoucherDto>
	{
		public GetListVoucherIgnoreQueryFilterQueryResponse(List<VoucherDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
