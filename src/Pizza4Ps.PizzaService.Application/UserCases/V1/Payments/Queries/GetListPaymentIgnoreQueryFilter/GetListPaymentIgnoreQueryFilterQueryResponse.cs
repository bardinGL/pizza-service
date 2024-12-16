using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPaymentIgnoreQueryFilter
{
	public class GetListPaymentIgnoreQueryFilterQueryResponse : PaginatedResultDto<PaymentDto>
	{
		public GetListPaymentIgnoreQueryFilterQueryResponse(List<PaymentDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
