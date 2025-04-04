﻿using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetListStaff
{
	public class GetListStaffQuery : IRequest<GetListStaffQueryResponse>
	{
		public GetListStaffDto GetListStaffDto { get; set; }
	}
}
