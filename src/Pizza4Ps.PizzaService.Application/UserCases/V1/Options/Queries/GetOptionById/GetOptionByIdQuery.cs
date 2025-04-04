﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetOptionById
{
	public class GetOptionByIdQuery : IRequest<GetOptionByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
