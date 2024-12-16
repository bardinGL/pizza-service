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
	public class OrderVoucherService : DomainService, IOrderVoucherService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IOrderVoucherRepository _orderVoucherRepository;

		public OrderVoucherService(IUnitOfWork unitOfWork, IOrderVoucherRepository orderVoucherRepository)
		{
			_unitOfWork = unitOfWork;
			_orderVoucherRepository = orderVoucherRepository;
		}

		public async Task<Guid> CreateAsync(Guid orderId, Guid voucherId)
		{
			var entity = new OrderVoucher(Guid.NewGuid(), orderId, voucherId);
			_orderVoucherRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _orderVoucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_orderVoucherRepository.HardDelete(entity);
				}
				else
				{
					_orderVoucherRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _orderVoucherRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_orderVoucherRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, Guid orderId, Guid voucherId)
		{
			var entity = await _orderVoucherRepository.GetSingleByIdAsync(id);
			entity.UpdateOrderVoucher(orderId, voucherId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
