﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.CreateSwapWorkingSlot
{
    public class CreateSwapWorkingSlotCommand : IRequest<ResultDto<Guid>>
    {
        public DateOnly WorkingDateFrom { get; set; }
        public Guid EmployeeFromId { get; set; }
        public Guid WorkingSlotFromId { get; set; }
        public DateOnly WorkingDateTo { get; set; }
        public Guid EmployeeToId { get; set; }
        public Guid WorkingSlotToId { get; set; }
    }
}
