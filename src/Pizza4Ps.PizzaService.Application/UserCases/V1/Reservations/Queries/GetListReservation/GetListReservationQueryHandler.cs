﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking
{
    public class GetListBookingQueryHandler : IRequestHandler<GetListBookingQuery, PaginatedResultDto<BookingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _BookingRepository;

        public GetListBookingQueryHandler(IMapper mapper, IBookingRepository BookingRepository)
        {
            _mapper = mapper;
            _BookingRepository = BookingRepository;
        }

        public async Task<PaginatedResultDto<BookingDto>> Handle(GetListBookingQuery request, CancellationToken cancellationToken)
        {
            BookingStatusEnum? bookingStatus = null;
            if (!string.IsNullOrEmpty(request.BookingStatus))
            {
                if (!Enum.TryParse(request.BookingStatus, true, out BookingStatusEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.INVALID_BOOKING_STATUS);
                }
                bookingStatus = parsedStatus;
            }

            var query = _BookingRepository.GetListAsNoTracking(
                x => (request.CustomerCode == null || x.CustomerCode.Equals(request.CustomerCode))
                && (request.PhoneNumber == null || x.PhoneNumber.Equals(request.PhoneNumber))
                && (request.BookingTime == null || x.BookingTime.Day.Equals(request.BookingTime.Value.Day))
                && (bookingStatus == null || x.BookingStatus == bookingStatus),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.BookingErrorConstant.BOOKING_NOT_FOUND);
            var result = _mapper.Map<List<BookingDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<BookingDto>(result, totalCount);
        }
    }
}
