﻿using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes
{
	public class GetListWorkingTimeIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public int? DayOfWeek { get; set; }
		public string? ShiftCode { get; set; }
		public string? Name { get; set; }
		public TimeSpan? StartTime { get; set; }
		public TimeSpan? EndTime { get; set; }
	}
}
