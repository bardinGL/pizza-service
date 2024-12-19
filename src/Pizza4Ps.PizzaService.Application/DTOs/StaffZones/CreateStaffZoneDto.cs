﻿namespace Pizza4Ps.PizzaService.Application.DTOs.StaffZones
{
	public class CreateStaffZoneDto
    {
        public DateOnly WorkDate { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
    }
}
