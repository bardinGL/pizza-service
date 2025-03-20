﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.RestoreBooking
{
	public class RestoreReservationCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
