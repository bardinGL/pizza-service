using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.StaffZones
{
	public class GetListStaffZoneIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public TimeOnly? ShiftStart { get; set; }
		public TimeOnly? ShiftEnd { get; set; }
		public string? Note { get; set; }
		public Guid? StaffId { get; set; }
		public Guid? ZoneId { get; set; }
	}
}
