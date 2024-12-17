using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.CreateProductOption
{
	public class CreateProductOptionCommand : IRequest<CreateProductOptionCommandResponse>
	{
		public CreateProductOptionDto CreateProductOptionDto { get; set; }
	}
}
