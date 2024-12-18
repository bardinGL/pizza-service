using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBooking
{
	public class GetListTableBookingQueryHandler : IRequestHandler<GetListTableBookingQuery, GetListTableBookingQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly ITableBookingRepository _TableBookingRepository;

		public GetListTableBookingQueryHandler(IMapper mapper, ITableBookingRepository TableBookingRepository)
		{
			_mapper = mapper;
			_TableBookingRepository = TableBookingRepository;
		}

		public async Task<GetListTableBookingQueryResponse> Handle(GetListTableBookingQuery request, CancellationToken cancellationToken)
		{
			var query = _TableBookingRepository.GetListAsNoTracking(
				x => (request.GetListTableBookingDto.OnholdTime == null || x.OnholdTime == request.GetListTableBookingDto.OnholdTime)
				&& (request.GetListTableBookingDto.TableId == null || x.TableId == request.GetListTableBookingDto.TableId)
				&& (request.GetListTableBookingDto.BookingId == null || x.BookingId == request.GetListTableBookingDto.BookingId),
				includeProperties: request.GetListTableBookingDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListTableBookingDto.SortBy)
				.Skip(request.GetListTableBookingDto.SkipCount).Take(request.GetListTableBookingDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.TableBookingErrorConstant.TABLEBOOKING_NOT_FOUND);
			var result = _mapper.Map<List<TableBookingDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListTableBookingQueryResponse(result, totalCount);
		}
	}
}
