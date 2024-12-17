using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.ProductOptions
{
	public class ProductOptionDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public Guid OptionId { get; set; }

		public virtual Product Product { get; set; }
		public virtual Option Option { get; set; }
	}
}
