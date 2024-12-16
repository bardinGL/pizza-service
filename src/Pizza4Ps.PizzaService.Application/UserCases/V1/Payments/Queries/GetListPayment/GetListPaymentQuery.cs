using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment
{
	public class GetListPaymentQuery : IRequest<GetListPaymentQueryResponse>
	{
		public GetListPaymentDto GetListPaymentDto { get; set; }
	}
}
