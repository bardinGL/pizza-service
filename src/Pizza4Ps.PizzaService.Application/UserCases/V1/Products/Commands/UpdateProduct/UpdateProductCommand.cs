using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct
{
	public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateProductDto UpdateProductDto { get; set; }
	}
}
