using System.Diagnostics;
using System.Xml.Linq;
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
	public class OptionItemOrderItemService : DomainService, IOptionItemOrderItemService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IOptionItemOrderItemRepository _optionItemOrderItemRepository;

		public OptionItemOrderItemService(IUnitOfWork unitOfWork, IOptionItemOrderItemRepository optionItemOrderItemRepository)
		{
			_unitOfWork = unitOfWork;
			_optionItemOrderItemRepository = optionItemOrderItemRepository;
		}

		public async Task<Guid> CreateAsync(string name, decimal additionalPrice, Guid optionItemId, Guid orderItemId)
		{
			var entity = new OptionItemOrderItem(Guid.NewGuid(), name, additionalPrice, optionItemId, orderItemId);
			_optionItemOrderItemRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _optionItemOrderItemRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_optionItemOrderItemRepository.HardDelete(entity);
				}
				else
				{
					_optionItemOrderItemRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _optionItemOrderItemRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_optionItemOrderItemRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, string name, decimal additionalPrice, Guid optionItemId, Guid orderItemId)
		{
			var entity = await _optionItemOrderItemRepository.GetSingleByIdAsync(id);
			entity.UpdateOptionItemOrderItem(name, additionalPrice, optionItemId, orderItemId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
