using Pizza4Ps.PizzaService.Application.DTOs.Staffs;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;

namespace Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules
{
    public class StaffZoneScheduleDto
    {
        public Guid Id { get; set; }
        public int DayofWeek { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid WorkingTimeId { get; set; }

        public virtual StaffDto Staff { get; set; }
        public virtual ZoneDto Zone { get; set; }
        public virtual WorkingTimeDto WorkingTime { get; set; }
    }
}
