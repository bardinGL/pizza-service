﻿using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Booking.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<CreateBookingCommandResponse>
    {
        public CreateBookingDto CreateBookingDto { get; set; }
    }
}
