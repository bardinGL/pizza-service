using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZone : EntityAuditBase<Guid>
    {
        public DateOnly WorkDate { get; set; }
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }

        public StaffZone()
        {
        }

        public StaffZone(Guid id, DateOnly workDate, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            Id = id;
            WorkDate = workDate;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
        }
    }
}