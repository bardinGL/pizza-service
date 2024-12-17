namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItems
{
	public class UpdateOptionItemDto
	{
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid OptionId { get; set; }
	}
}
