﻿using Pizza4Ps.PizzaService.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public StaffZoneSchedule()
        {
        }

        public StaffZoneSchedule(Guid id, DateOnly dayofWeek, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId, Staff staff, Zone zone)
        {
            Id = id;
            DayofWeek = dayofWeek;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
            Staff = staff;
            Zone = zone;
        }
    }
}
