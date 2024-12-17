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
	public class OptionItemService : DomainService, IOptionItemService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IOptionItemRepository _optionItemRepository;

		public OptionItemService(IUnitOfWork unitOfWork, IOptionItemRepository optionItemRepository)
		{
			_unitOfWork = unitOfWork;
			_optionItemRepository = optionItemRepository;
		}

		public async Task<Guid> CreateAsync(string name, decimal additionalPrice, Guid optionId)
		{
			var entity = new OptionItem(Guid.NewGuid(), name, additionalPrice, optionId);
			_optionItemRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _optionItemRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_optionItemRepository.HardDelete(entity);
				}
				else
				{
					_optionItemRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _optionItemRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_optionItemRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, string name, decimal additionalPrice, Guid optionId)
		{
			var entity = await _optionItemRepository.GetSingleByIdAsync(id);
			entity.UpdateOptionItem(name, additionalPrice, optionId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
