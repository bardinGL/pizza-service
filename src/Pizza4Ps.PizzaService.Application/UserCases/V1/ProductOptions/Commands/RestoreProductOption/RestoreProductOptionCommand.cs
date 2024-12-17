using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.RestoreProductOption
{
	public class RestoreProductOptionCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
