using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZoneSchedule : EntityAuditBase<Guid>
    {
        public int DayofWeek { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid WorkingTimeId { get; set; }


        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual WorkingTime WorkingTime { get; set; }

        public Guid Guid { get; }

        public StaffZoneSchedule()
        {
        }

        public StaffZoneSchedule(Guid id, int dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId, Guid workingtimeId)
        {
            Id = id;
            DayofWeek = dayofWeek;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
            WorkingTimeId = workingtimeId;
        }

        public void UpdateStaffZoneSchedule(int dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId, Guid workingtimeId)
        {
            DayofWeek = dayofWeek;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
            WorkingTimeId = workingtimeId;
        }
    }
}
