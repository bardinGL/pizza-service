﻿using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class OrderItemDetail : EntityAuditBase<Guid>
	{
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid? OrderItemId { get; set; }
		public virtual OrderItem OrderItem { get; set; }

		public OrderItemDetail()
		{
		}

		public OrderItemDetail(Guid id, string name, decimal additionalPrice, Guid orderItemId)
		{
			Id = id;
			Name = name;
			AdditionalPrice = additionalPrice;
			OrderItemId = orderItemId;
		}

		public void UpdateOptionItemOrderItem(string name, decimal additionalPrice, Guid orderItemId)
		{
			Name = name;
			AdditionalPrice = additionalPrice;
			OrderItemId = orderItemId;
		}
	}
}
