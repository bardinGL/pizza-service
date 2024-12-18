using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOption
{
	public class GetListProductOptionQuery : IRequest<GetListProductOptionQueryResponse>
	{
		public GetListProductOptionDto GetListProductOptionDto { get; set; }
	}
}