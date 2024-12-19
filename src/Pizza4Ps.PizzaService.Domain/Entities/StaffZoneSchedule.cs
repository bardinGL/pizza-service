﻿using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class StaffZoneSchedule : EntityAuditBase<Guid>
	{
		public DateOnly DayofWeek { get; set; }
		public TimeOnly ShiftStart { get; set; }
		public TimeOnly ShiftEnd { get; set; }
		public string Note { get; set; }
		public Guid StaffId { get; set; }
		public Guid ZoneId { get; set; }

		public virtual Staff Staff { get; set; }
		public virtual Zone Zone { get; set; }
        public Guid Guid { get; }

        public StaffZoneSchedule()
		{
		}

		public StaffZoneSchedule(Guid id, DateOnly dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
		{
			Id = id;
			DayofWeek = dayofWeek;
			ShiftStart = shiftStart;
			ShiftEnd = shiftEnd;
			Note = note;
			StaffId = staffId;
			ZoneId = zoneId;
		}

        public void UpdateStaffZoneSchedule(DateOnly dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            DayofWeek = dayofWeek;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
        }
    }
}
