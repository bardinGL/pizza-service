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
	public class FeedbackService : DomainService, IFeedbackService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFeedbackRepository _feedbackRepository;

		public FeedbackService(IUnitOfWork unitOfWork, IFeedbackRepository feedbackRepository)
		{
			_unitOfWork = unitOfWork;
			_feedbackRepository = feedbackRepository;
		}

		public async Task<Guid> CreateAsync(int rating, string comments, Guid orderId)
		{
			var entity = new Feedback(Guid.NewGuid(), rating, comments, orderId);
			_feedbackRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _feedbackRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_feedbackRepository.HardDelete(entity);
				}
				else
				{
					_feedbackRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _feedbackRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_feedbackRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, int rating, string comments, Guid orderId)
		{
			var entity = await _feedbackRepository.GetSingleByIdAsync(id);
			entity.UpdateFeedback(rating, comments, orderId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
