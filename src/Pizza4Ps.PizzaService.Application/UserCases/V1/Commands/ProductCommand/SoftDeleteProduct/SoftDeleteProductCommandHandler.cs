using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.HardDeleteProduct;
using Pizza4Ps.PizzaService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.SoftDeleteProduct
{
    public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand>
    {
        private readonly ProductService _productService;

        public SoftDeleteProductCommandHandler(ProductService productService)
        {
            _productService = productService;
        }
        public async Task Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.SoftDeleteProductAsync(request.Id);
        }
    }
}
