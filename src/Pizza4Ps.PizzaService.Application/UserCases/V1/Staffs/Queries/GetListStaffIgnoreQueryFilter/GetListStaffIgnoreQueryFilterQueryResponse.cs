﻿using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetListStaffIgnoreQueryFilter
{
	public class GetListStaffIgnoreQueryFilterQueryResponse : PaginatedResultDto<StaffDto>
	{
		public GetListStaffIgnoreQueryFilterQueryResponse(List<StaffDto> items, long totalCount) : base(items, totalCount)
		{
		}
	}
}
