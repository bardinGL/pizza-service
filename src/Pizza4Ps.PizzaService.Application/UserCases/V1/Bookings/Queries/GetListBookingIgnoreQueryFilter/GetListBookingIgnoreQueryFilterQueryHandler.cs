using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBookingIgnoreQueryFilter
{
    public class GetListBookingIgnoreQueryFilterQueryHandler : IRequestHandler<GetListBookingIgnoreQueryFilterQuery, GetListBookingIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _BookingRepository;

        public GetListBookingIgnoreQueryFilterQueryHandler(IMapper mapper, IBookingRepository BookingRepository)
        {
            _mapper = mapper;
            _BookingRepository = BookingRepository;
        }

        public async Task<GetListBookingIgnoreQueryFilterQueryResponse> Handle(GetListBookingIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _BookingRepository.GetListAsNoTracking(includeProperties: request.GetListBookingIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListBookingIgnoreQueryFilterDto.BookingDate == null || x.BookingDate == request.GetListBookingIgnoreQueryFilterDto.BookingDate)
                    && (request.GetListBookingIgnoreQueryFilterDto.GuestCount == null || x.GuestCount == request.GetListBookingIgnoreQueryFilterDto.GuestCount)
                    && (request.GetListBookingIgnoreQueryFilterDto.Status == null || x.Status == request.GetListBookingIgnoreQueryFilterDto.Status)
                    && (request.GetListBookingIgnoreQueryFilterDto.CustomerId == null || x.CustomerId == request.GetListBookingIgnoreQueryFilterDto.CustomerId)
                    && x.IsDeleted == request.GetListBookingIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListBookingIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListBookingIgnoreQueryFilterDto.SkipCount).Take(request.GetListBookingIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<BookingDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListBookingIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
