﻿using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems
{
	public class GetListOptionItemOrderItemIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public string? Name { get; set; }
		public decimal? AdditionalPrice { get; set; }
	}
}
