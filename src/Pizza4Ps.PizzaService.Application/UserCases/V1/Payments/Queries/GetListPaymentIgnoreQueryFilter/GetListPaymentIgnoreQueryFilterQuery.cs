using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPaymentIgnoreQueryFilter
{
	public class GetListPaymentIgnoreQueryFilterQuery : IRequest<GetListPaymentIgnoreQueryFilterQueryResponse>
	{
		public GetListPaymentIgnoreQueryFilterDto GetListPaymentIgnoreQueryFilterDto { get; set; }
	}
}
