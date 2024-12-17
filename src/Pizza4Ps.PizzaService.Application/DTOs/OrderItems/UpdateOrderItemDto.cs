namespace Pizza4Ps.PizzaService.Application.DTOs.OrderItems
{
	public class UpdateOrderItemDto
	{
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
	}
}
