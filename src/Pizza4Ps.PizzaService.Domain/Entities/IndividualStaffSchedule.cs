using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class IndividualStaffSchedule : EntityAuditBase<Guid>
	{
		public DateOnly ScheduleDate { get; set; }
		public TimeOnly ShiftStart { get; set; }
		public TimeOnly ShiftEnd { get; set; }
		public IndividualStaffScheduleTypeEnum Status { get; set; }
		public Guid StaffId { get; set; }
		public Guid ScheduleId { get; set; }
		public virtual Staff Staff { get; set; }
		public virtual StaffSchedule StaffSchedule { get; set; }

		private IndividualStaffSchedule() { }

		public IndividualStaffSchedule(Guid id ,DateOnly scheduleDate, TimeOnly shiftStart, TimeOnly shiftEnd, IndividualStaffScheduleTypeEnum status, Guid staffId, Guid scheduleId, Staff staff, StaffSchedule staffSchedule)
        {
			Id = id;
            ScheduleDate = scheduleDate;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            Status = status;
            StaffId = staffId;
            ScheduleId = scheduleId;
            Staff = staff;
            StaffSchedule = staffSchedule;
        }
    }
}
