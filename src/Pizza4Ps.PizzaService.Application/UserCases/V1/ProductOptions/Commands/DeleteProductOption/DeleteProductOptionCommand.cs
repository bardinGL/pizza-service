using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.DeleteProductOption
{
	public class DeleteProductOptionCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
