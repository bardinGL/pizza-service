﻿using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetListStaffIgnoreQueryFilter
{
    public class GetListStaffIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<StaffDto>>
    {
        //public bool IsDeleted { get; set; } = false;
        //public string? Code { get; set; }
        //public string? Name { get; set; }
        //public string? Phone { get; set; }
        //public string? Email { get; set; }
        //public string? StaffType { get; set; }
        //public string? Status { get; set; }
    }
}
