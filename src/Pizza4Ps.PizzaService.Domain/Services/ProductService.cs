using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
	public class ProductService : DomainService, IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductRepository _productRepository;

		public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
		{
			_unitOfWork = unitOfWork;
			_productRepository = productRepository;
		}

		public async Task<Guid> CreateAsync(string name, decimal price, string description, Guid categoryId)
		{
			var entity = new Product(Guid.NewGuid(), name, price, description, categoryId);
			_productRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _productRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_productRepository.HardDelete(entity);
				}
				else
				{
					_productRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _productRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_productRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, string name, decimal price, string description, Guid categoryId)
		{
			var entity = await _productRepository.GetSingleByIdAsync(id);
			entity.UpdateProduct(name, price, description, categoryId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
