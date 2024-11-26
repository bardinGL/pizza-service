using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.CreateProduct;
using Pizza4Ps.PizzaService.Domain.Services;
using StructureCodeSolution.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.HardDeleteProduct
{
    public class HardDeleteProductCommandHandler : IRequestHandler<HardDeleteProductCommand>
    {
        private readonly ProductService _productService;

        public HardDeleteProductCommandHandler(ProductService productservice)
        {
            _productService = productservice;
        }
        public async Task Handle(HardDeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.HardDeleteProductAsync(request.Id);
        }
    }
}
