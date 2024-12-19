using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules
{
    public class GetListStaffScheduleDto : PaginatedRequestDto
    {
        public DateTimeOffset? SchedualDate { get; set; }
        public TimeSpan? ShiftStart { get; set; }
        public TimeSpan? ShiftEnd { get; set; }
        public ConfigEnum? Status { get; set; }
        public Guid? StaffId { get; set; }
        public Guid? ZoneId { get; set; }
    }
}
