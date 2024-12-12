﻿using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CreateTable
{
    public class CreateTableCommand : IRequest<CreateTableCommandResponse>
    {
        public Guid Id { get; set; }
        public CreateTableDto CreateTableDto { get; set; }
    }
}
