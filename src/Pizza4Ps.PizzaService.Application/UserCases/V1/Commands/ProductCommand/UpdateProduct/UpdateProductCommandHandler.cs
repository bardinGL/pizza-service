using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public UpdateProductCommandHandler(IMapper mapper, ProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            return await _productService.UpdateProductAsync(product);
        }
    }
}
