using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
	public class BookingService : DomainService, IBookingService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IBookingRepository _bookingRepository;

		public BookingService(IUnitOfWork unitOfWork, IBookingRepository bookingRepository)
		{
			_unitOfWork = unitOfWork;
			_bookingRepository = bookingRepository;
		}

		public async Task<Guid> CreateAsync(DateTime bookingDate, int guestCount, string status, Guid customerId)
		{
			var entity = new Booking(Guid.NewGuid(), bookingDate, guestCount, status, customerId);
			_bookingRepository.Add(entity);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}

		public Task<Guid> CreateAsync(string name, string description)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
		{
			var entities = await _bookingRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				if (IsHardDeleted)
				{
					_bookingRepository.HardDelete(entity);
				}
				else
				{
					_bookingRepository.SoftDelete(entity);
				}
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task RestoreAsync(List<Guid> ids)
		{
			var entities = await _bookingRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
			if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
			foreach (var entity in entities)
			{
				_bookingRepository.Restore(entity);
			}
			await _unitOfWork.SaveChangeAsync();
		}

		public async Task<Guid> UpdateAsync(Guid id, DateTime bookingDate, int guestCount, string status, Guid customerId)
		{
			var entity = await _bookingRepository.GetSingleByIdAsync(id);
			entity.UpdateBooking(bookingDate, guestCount, status, customerId);
			await _unitOfWork.SaveChangeAsync();
			return entity.Id;
		}
	}
}
