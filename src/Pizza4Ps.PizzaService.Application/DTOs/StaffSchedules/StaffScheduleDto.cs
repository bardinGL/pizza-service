using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules
{
    public class StaffScheduleDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset SchedualDate { get; set; }
        public TimeSpan ShiftStart { get; set; }
        public TimeSpan ShiftEnd { get; set; }
        public ConfigEnum Status { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
