using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;
using StructureCodeSolution.Domain.Abstractions;
using StructureCodeSolution.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task<Guid> CreateProductAsync(Product product)
        {
            //var product = await _productRepository.GetAll().ToListAsync();

            //if (product == null)
            //{
            //    throw new Exception();
            //}
            var productEntity = new Product(product.Id, product.Name, product.Price, product.Description, product.CategoryId);
            _productRepository.Add(productEntity);
            await _unitOfWork.SaveChangeAsync();
            return productEntity.Id;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            var updatedProduct = new Product(
                product.Id,
                product.Name,
                product.Price,
                product.Description,
                product.CategoryId
            );

            _productRepository.Update(updatedProduct);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }



    }
}
