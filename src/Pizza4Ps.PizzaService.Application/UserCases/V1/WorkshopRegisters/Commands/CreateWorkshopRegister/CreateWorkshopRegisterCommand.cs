﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CreateWorkshopRegister
{
    public class CreateWorkshopRegisterCommand : IRequest<ResultDto<Guid>>
    {
        public Guid CustomerId { get; set; }

        public Guid WorkshopId { get; set; }

        public int TotalParticipant { get; set; }

        public List<CreateWorkshopPizzaRegisterCommand> Products { get;set; }
    }
    // Command đăng ký pizza (cấp 2)
    public class CreateWorkshopPizzaRegisterCommand
    {
        public Guid ProductId { get; set; }
        public List<Guid> OptionItemIds { get; set; }
    }
}
