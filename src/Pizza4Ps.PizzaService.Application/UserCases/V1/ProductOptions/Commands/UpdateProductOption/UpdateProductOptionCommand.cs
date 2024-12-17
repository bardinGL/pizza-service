using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.UpdateProductOption
{
	public class UpdateProductOptionCommand : IRequest<UpdateProductOptionCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateProductOptionDto UpdateProductOptionDto { get; set; }
	}
}
