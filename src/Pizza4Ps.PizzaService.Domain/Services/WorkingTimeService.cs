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
	public class WorkingTimeService : DomainService, IWorkingTimeService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWorkingTimeRepository _workingTimeRepository;

		public WorkingTimeService(IUnitOfWork unitOfWork, IWorkingTimeRepository workingTimeRepository)
		{
			_unitOfWork = unitOfWork;
			_workingTimeRepository = workingTimeRepository;
		}

		public async Task<Guid> CreateAsync(int dayOfWeek, string shiftCode, string name, TimeSpan startTime, TimeSpan endTime)
		{
			var entity = new WorkingTime(Guid.NewGuid(), dayOfWeek, shiftCode, name, startTime, endTime);
			_workingTimeRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _workingTimeRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_workingTimeRepository.HardDelete(entity);
				}
				else
				{
					_workingTimeRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _workingTimeRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_workingTimeRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, int dayOfWeek, string shiftCode, string name, TimeSpan startTime, TimeSpan endTime)
		{
			var entity = await _workingTimeRepository.GetSingleByIdAsync(id);
			entity.UpdateWorkingTime(dayOfWeek, shiftCode, name, startTime, endTime);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
