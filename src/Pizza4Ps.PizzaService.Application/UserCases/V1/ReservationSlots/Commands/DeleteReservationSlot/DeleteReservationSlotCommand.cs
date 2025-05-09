﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReservationSlots.Commands.DeleteReservationSlot
{
    public class DeleteReservationSlotCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
