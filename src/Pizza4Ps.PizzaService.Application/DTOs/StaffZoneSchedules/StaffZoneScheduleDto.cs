using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules
{
    public class StaffZoneScheduleDto
    {
        public Guid Id { get; set; }
        public DateOnly DayofWeek { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid WorkingTimeId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual WorkingTime WorkingTime { get; set; }
    }
}
