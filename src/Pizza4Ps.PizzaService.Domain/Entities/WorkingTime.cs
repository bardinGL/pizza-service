using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class WorkingTime : EntityAuditBase<Guid>
	{
		public int DayOfWeek { get; set; }
		public string ShiftCode { get; set; }
		public string Name { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }

		public WorkingTime()
		{
		}

		public WorkingTime(Guid id, int dayOfWeek, string shiftCode, string name, TimeSpan startTime, TimeSpan endTime)
		{
			Id = id;
			DayOfWeek = dayOfWeek;
			ShiftCode = shiftCode;
			Name = name;
			StartTime = startTime;
			EndTime = endTime;
		}

		public void UpdateWorkingTime(int dayOfWeek, string shiftCode, string name, TimeSpan startTime, TimeSpan endTime)
		{
			DayOfWeek = dayOfWeek;
			ShiftCode = shiftCode;
			Name = name;
			StartTime = startTime;
			EndTime = endTime;
		}
	}
}
