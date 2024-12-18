﻿using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucher
{
	public class GetListOrderVoucherQueryResponse : PaginatedResultDto<OrderVoucherDto>
	{
		public GetListOrderVoucherQueryResponse(List<OrderVoucherDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
