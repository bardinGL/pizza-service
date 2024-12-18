using Pizza4Ps.PizzaService.Application.DTOs.Orders;
using Pizza4Ps.PizzaService.Application.DTOs.Products;

namespace Pizza4Ps.PizzaService.Application.DTOs.OrderItems
{
	public class OrderItemDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }

		public virtual OrderDto Order { get; set; }
		public virtual ProductDto Product { get; set; }
	}
}
