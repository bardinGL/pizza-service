using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking
{
	public class GetListBookingQueryHandler : IRequestHandler<GetListBookingQuery, GetListBookingQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBookingRepository _BookingRepository;

		public GetListBookingQueryHandler(IMapper mapper, IBookingRepository BookingRepository)
		{
			_mapper = mapper;
			_BookingRepository = BookingRepository;
		}

		public async Task<GetListBookingQueryResponse> Handle(GetListBookingQuery request, CancellationToken cancellationToken)
		{
			var query = _BookingRepository.GetListAsNoTracking(
				x => (request.GetListBookingDto.BookingDate == null || x.BookingDate == request.GetListBookingDto.BookingDate)
				&& (request.GetListBookingDto.GuestCount == null || x.GuestCount == request.GetListBookingDto.GuestCount)
				&& (request.GetListBookingDto.Status == null || x.Status == request.GetListBookingDto.Status)
				&& (request.GetListBookingDto.CustomerId == null || x.CustomerId == request.GetListBookingDto.CustomerId),
				includeProperties: request.GetListBookingDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListBookingDto.SortBy)
				.Skip(request.GetListBookingDto.SkipCount).Take(request.GetListBookingDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.BOOKING_NOT_FOUND);
			var result = _mapper.Map<List<BookingDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListBookingQueryResponse(result, totalCount);
		}
	}
}
