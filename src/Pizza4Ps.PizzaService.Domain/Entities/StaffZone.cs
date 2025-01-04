using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffZone : EntityAuditBase<Guid>
    {
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

        public StaffZone(Guid id, TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            Id = id;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
        }

        public void UpdateStaffZone(TimeOnly shiftStart, TimeOnly shiftEnd, string note, Guid staffId, Guid zoneId)
        {
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Note = note;
            StaffId = staffId;
            ZoneId = zoneId;
        }
    }
}