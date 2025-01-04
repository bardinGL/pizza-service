namespace Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules
{
    public class CreateStaffZoneScheduleDto
    {
        public int DayofWeek { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid WorkingTimeId { get; set; }
    }
}
