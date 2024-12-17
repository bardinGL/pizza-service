using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.RestoreProductOption
{
	public class RestoreProductOptionCommandHandler : IRequestHandler<RestoreProductOptionCommand>
	{
		private readonly IProductOptionService _productOptionService;

		public RestoreProductOptionCommandHandler(IProductOptionService productOptionService)
		{
			_productOptionService = productOptionService;
		}

		public async Task Handle(RestoreProductOptionCommand request, CancellationToken cancellationToken)
		{
			await _productOptionService.RestoreAsync(request.Ids);
		}
	}
}
