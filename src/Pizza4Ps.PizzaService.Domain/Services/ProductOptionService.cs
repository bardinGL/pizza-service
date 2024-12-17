using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
	public class ProductOptionService : DomainService, IProductOptionService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductOptionRepository _productOptionRepository;

		public ProductOptionService(IUnitOfWork unitOfWork, IProductOptionRepository productOptionRepository)
		{
			_unitOfWork = unitOfWork;
			_productOptionRepository = productOptionRepository;
		}

		public async Task<Guid> CreateAsync(Guid productId, Guid optionId)
		{
			var entity = new ProductOption(Guid.NewGuid(), productId, optionId);
			_productOptionRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _productOptionRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_productOptionRepository.HardDelete(entity);
				}
				else
				{
					_productOptionRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _productOptionRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_productOptionRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, Guid productId, Guid optionId)
		{
			var entity = await _productOptionRepository.GetSingleByIdAsync(id);
			entity.UpdateProductOption(productId, optionId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
