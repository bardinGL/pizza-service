using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
	public class GetListVoucherIgnoreQueryFilterQuery : IRequest<GetListVoucherIgnoreQueryFilterQueryResponse>
	{
		public GetListVoucherIgnoreQueryFilterDto GetListVoucherIgnoreQueryFilterDto { get; set; }
	}
}
