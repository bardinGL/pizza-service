﻿using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.CreateStaff
{
	public class CreateStaffCommand : IRequest<CreateStaffCommandResponse>
	{
		public CreateStaffDto CreateStaffDto { get; set; }
	}
}
