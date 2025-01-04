using Pizza4Ps.PizzaService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules
{
    public class CreateStaffScheduleDto
    {
        public DateTimeOffset SchedualDate { get; set; }
        public TimeSpan ShiftStart { get; set; }
        public TimeSpan ShiftEnd { get; set; }
        public ConfigEnum Status { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }
    }
}
