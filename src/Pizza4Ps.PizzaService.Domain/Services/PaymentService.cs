using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
	public class PaymentService : DomainService, IPaymentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPaymentRepository _paymentRepository;

		public PaymentService(IUnitOfWork unitOfWork, IPaymentRepository paymentRepository)
		{
			_unitOfWork = unitOfWork;
			_paymentRepository = paymentRepository;
		}

		public async Task<Guid> CreateAsync(decimal amount, PaymentMethodEnum paymentMethod, string status, Guid orderId)
		{
			var entity = new Payment(Guid.NewGuid(), amount, paymentMethod, status, orderId);
			_paymentRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _paymentRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_paymentRepository.HardDelete(entity);
				}
				else
				{
					_paymentRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _paymentRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_paymentRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, decimal amount, PaymentMethodEnum paymentMethod, string status, Guid orderId)
		{
			var entity = await _paymentRepository.GetSingleByIdAsync(id);
			entity.UpdatePayment(amount, paymentMethod, status, orderId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
