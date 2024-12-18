using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBookingIgnoreQueryFilter
{
	public class GetListTableBookingIgnoreQueryFilterQueryHandler : IRequestHandler<GetListTableBookingIgnoreQueryFilterQuery, GetListTableBookingIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly ITableBookingRepository _TableBookingRepository;

		public GetListTableBookingIgnoreQueryFilterQueryHandler(IMapper mapper, ITableBookingRepository TableBookingRepository)
		{
			_mapper = mapper;
			_TableBookingRepository = TableBookingRepository;
		}

		public async Task<GetListTableBookingIgnoreQueryFilterQueryResponse> Handle(GetListTableBookingIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _TableBookingRepository.GetListAsNoTracking(includeProperties: request.GetListTableBookingIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListTableBookingIgnoreQueryFilterDto.OnholdTime == null || x.OnholdTime == request.GetListTableBookingIgnoreQueryFilterDto.OnholdTime)
					&& (request.GetListTableBookingIgnoreQueryFilterDto.TableId == null || x.TableId == request.GetListTableBookingIgnoreQueryFilterDto.TableId)
					&& (request.GetListTableBookingIgnoreQueryFilterDto.BookingId == null || x.BookingId == request.GetListTableBookingIgnoreQueryFilterDto.BookingId)
					&& x.IsDeleted == request.GetListTableBookingIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListTableBookingIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListTableBookingIgnoreQueryFilterDto.SkipCount).Take(request.GetListTableBookingIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<TableBookingDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListTableBookingIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
