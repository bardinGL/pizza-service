﻿using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrder
{
	public class GetListOrderQuery : IRequest<GetListOrderQueryResponse>
	{
		public GetListOrderDto GetListOrderDto { get; set; }
	}
}
