﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetOrderById
{
	public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
