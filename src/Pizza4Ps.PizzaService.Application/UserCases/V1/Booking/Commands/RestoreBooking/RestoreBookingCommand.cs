﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Booking.Commands.RestoreBooking
{
    public class RestoreBookingCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
