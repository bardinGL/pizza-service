using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQueryHandler: IRequestHandler<GetBookingByIdQuery, GetBookingByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _BookingRepository;

        public GetBookingByIdQueryHandler(IMapper mapper, IBookingRepository BookingRepository)
        {
            _mapper = mapper;
            _BookingRepository = BookingRepository;
        }

        public async Task<GetBookingByIdQueryResponse> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _BookingRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<BookingDto>(entity);
            return new GetBookingByIdQueryResponse
            {
                Booking = result
            };
        }
    }
}
