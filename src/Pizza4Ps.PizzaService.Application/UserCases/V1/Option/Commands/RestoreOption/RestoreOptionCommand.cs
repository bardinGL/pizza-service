﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.RestoreOption
{
	public class RestoreOptionCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
