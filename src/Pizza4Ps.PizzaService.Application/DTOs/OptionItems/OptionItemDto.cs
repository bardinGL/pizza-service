using Pizza4Ps.PizzaService.Application.DTOs.Options;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.OptionItems
{
	public class OptionItemDto
	{
        public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal AdditionalPrice { get; set; }
		public Guid OptionId { get; set; }

		public virtual OptionDto Option { get; set; }
	}
}
