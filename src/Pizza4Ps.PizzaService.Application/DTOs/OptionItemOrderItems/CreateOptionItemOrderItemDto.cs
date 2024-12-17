﻿using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems
{
	public class CreateOptionItemOrderItemDto
	{
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid OptionItemId { get; set; }
		public Guid OrderItemId { get; set; }
	}
}
