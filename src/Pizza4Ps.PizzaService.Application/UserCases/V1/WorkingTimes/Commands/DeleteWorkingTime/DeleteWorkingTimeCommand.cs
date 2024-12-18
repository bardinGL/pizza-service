﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.DeleteWorkingTime
{
	public class DeleteWorkingTimeCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
