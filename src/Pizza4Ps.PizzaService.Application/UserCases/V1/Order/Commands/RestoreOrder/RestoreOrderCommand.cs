﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.RestoreOrder
{
	public class RestoreOrderCommand : BaseRestoreCommand<Guid>, IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
