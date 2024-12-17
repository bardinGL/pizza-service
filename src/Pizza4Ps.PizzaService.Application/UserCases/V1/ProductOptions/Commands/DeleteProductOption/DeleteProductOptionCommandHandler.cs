using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.DeleteProductOption
{
	public class DeleteProductOptionCommandHandler : IRequestHandler<DeleteProductOptionCommand>
	{
		private readonly IProductOptionService _productOptionService;

		public DeleteProductOptionCommandHandler(IProductOptionService productOptionService)
		{
			_productOptionService = productOptionService;
		}

		public async Task Handle(DeleteProductOptionCommand request, CancellationToken cancellationToken)
		{
			await _productOptionService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
