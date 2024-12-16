using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment
{
	public class GetListPaymentQueryResponse : PaginatedResultDto<PaymentDto>
	{
		public GetListPaymentQueryResponse(List<PaymentDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
