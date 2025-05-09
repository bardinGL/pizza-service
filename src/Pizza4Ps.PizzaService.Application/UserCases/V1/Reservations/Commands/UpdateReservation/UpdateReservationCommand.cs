﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.UpdateBooking
{
    public class UpdateReservationCommand : IRequest
	{
		public Guid? Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int GuestCount { get; set; }
    }
}

