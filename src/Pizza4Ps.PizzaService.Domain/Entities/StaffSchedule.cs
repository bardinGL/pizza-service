using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class StaffSchedule : EntityAuditBase<Guid>
    {
        public DateTimeOffset SchedualDate {  get; set; }
        public TimeSpan ShiftStart {  get; set; }
        public TimeSpan ShiftEnd {  get; set; }
        public ConfigEnum Status { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }

        public StaffSchedule()
        {
        }

        public StaffSchedule(DateTimeOffset schedualDate, TimeSpan shiftStart, TimeSpan shiftEnd, ConfigEnum status, Guid staffId, Guid zoneId)
        {
            SchedualDate = schedualDate;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Status = status;
            StaffId = staffId;
            ZoneId = zoneId;
        }
    }
}
