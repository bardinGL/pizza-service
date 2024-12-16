using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs.Zones
{
	public class ZoneDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Capacity { get; set; }
		public string Description { get; set; }
		public ZoneTypeEnum Status { get; set; } = ZoneTypeEnum.Available;
	}
}
