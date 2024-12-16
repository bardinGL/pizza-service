using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
	public class TableBookingService : DomainService, ITableBookingService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITableBookingRepository _tableBookingRepository;

		public TableBookingService(IUnitOfWork unitOfWork, ITableBookingRepository tableBookingRepository)
		{
			_unitOfWork = unitOfWork;
			_tableBookingRepository = tableBookingRepository;
		}

		public async Task<Guid> CreateAsync(DateTime onholdTime, Guid tableId, Guid bookingId)
		{
			var entity = new TableBooking(Guid.NewGuid(), onholdTime, tableId, bookingId);
			_tableBookingRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _tableBookingRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_tableBookingRepository.HardDelete(entity);
				}
				else
				{
					_tableBookingRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _tableBookingRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_tableBookingRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, DateTime onholdTime, Guid tableId, Guid bookingId)
		{
			var entity = await _tableBookingRepository.GetSingleByIdAsync(id);
			entity.UpdateTableBooking(onholdTime, tableId, bookingId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
